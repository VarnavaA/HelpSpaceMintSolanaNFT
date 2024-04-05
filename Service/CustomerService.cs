using System;
using System.Security.Principal;
using HelpSpace.Helpers;
using HelpSpace.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Solnet.Metaplex.Candymachine.Core.Types;
using Solnet.Metaplex.NFT;
using Solnet.Programs;
using Solnet.Rpc;
using Solnet.Rpc.Builders;
using Solnet.Rpc.Core.Http;
using Solnet.Rpc.Messages;
using Solnet.Rpc.Models;
using Solnet.Wallet;
using Solnet.Metaplex.NFT.Library;
using Creator = Solnet.Metaplex.NFT.Library.Creator;
using Solnet.Rpc.Types;

namespace HelpSpace.Service
{
    public interface ICustomerService
    {
        Task<string> CreateCustomerProd(CreateNFTRequest createNFTRequest);
        Task<string> CreateCustomerDev(CreateNFTRequest createNFTRequest);
    }


    public class CustomerService : ICustomerService
    {
        private readonly AppSettings _appSettings;

        private static IRpcClient _rpcClient = ClientFactory.GetClient(Cluster.MainNet);

        private string _mnemonicWords;

        private static readonly byte[] DevNetSeedWithoutPassphrase =
        { 73, 39, 116, 218, 229, 53, 19, 110, 1, 173, 214, 224,
            201, 49, 217, 111, 94, 95, 145, 226, 74, 39, 66, 1,
            169, 189, 92, 114, 131, 159, 111, 53, 212, 60, 195,
            201, 53, 195, 67, 144, 40, 240, 61, 20, 136, 124,
            124, 8, 36, 57, 202, 68, 239, 213, 50, 192, 179,
            150, 104, 248, 50, 32, 216, 176 };

        IAkordService _akordService;

        public CustomerService(IOptions<AppSettings> appSettings, IAkordService akordService)
        {
            _appSettings = appSettings.Value;

            _mnemonicWords = _appSettings.ProdMnemonicWords;

            _akordService = akordService;
        }

        public async Task<string> CreateCustomerProd(CreateNFTRequest createNFTRequest)
        {
            _rpcClient = ClientFactory.GetClient(Cluster.MainNet);

            var dataFrom = await _akordService.SaveFile(createNFTRequest);

            SaveNFTResponce saveNFT = JsonConvert.DeserializeObject<SaveNFTResponce>(dataFrom);

            Wallet wallet = new Wallet(_mnemonicWords);

            if (saveNFT.tx.gatewayUrls.Count > 0)
            {
                string url = saveNFT.tx.gatewayUrls.LastOrDefault();

                return CreateCustomerViaMetaplex(
                     url,
                     $"HS_NFT_{createNFTRequest.Name}",
                     $"HS",
                     createNFTRequest.SolanaKey,
                     wallet
                     );

            }

            return string.Empty;
        }


        public async Task<string> CreateCustomerDev(CreateNFTRequest createNFTRequest)
        {
            _rpcClient = ClientFactory.GetClient(Cluster.DevNet);

            var dataFrom = await _akordService.SaveFile(createNFTRequest);

            SaveNFTResponce saveNFT = JsonConvert.DeserializeObject<SaveNFTResponce>(dataFrom);

            Wallet wallet = new Wallet(DevNetSeedWithoutPassphrase, "", SeedMode.Bip39);

            if (saveNFT.tx.gatewayUrls.Count > 0)
            {
                string url = saveNFT.tx.gatewayUrls.LastOrDefault();

                return CreateCustomerViaMetaplex(
                     url,
                     $"HS_NFT_{createNFTRequest.Name}",
                     $"HS",
                     createNFTRequest.SolanaKey,
                     wallet
                     );
            }

            return string.Empty;
        }


        private string CreateCustomerViaMetaplex(string metaDataUri, string name, string symbol, string solanaKey, Wallet wallet)
        {

            Console.WriteLine($"PubKey: {wallet.Account.PublicKey.Key}");

            Account mintAccount = new Account();

            Console.WriteLine($"mintAccountPubKey: {mintAccount.PublicKey.Key}");

            RequestResult<ResponseValue<ulong>> balance =
                 _rpcClient.GetBalance(wallet.Account.PublicKey, Commitment.Confirmed);

            Console.WriteLine($"Balance: {balance.Result.Value} ");

            if (balance.Result != null && balance.Result.Value < SolanaUtils.SolToLamports / 10)
            {
                Console.WriteLine("Sol balance is low. Minting may fail", true);
            }

            var creator1 = new Creator(wallet.Account.PublicKey, 100);
            Metadata data = new Metadata
            {
                name = name,
                symbol = symbol,
                sellerFeeBasisPoints = 0,
                uri = metaDataUri,
                creators = new List<Creator>() { creator1 }
            };

            MetadataClient metaplexClient = new MetadataClient(_rpcClient);

             var tx =  metaplexClient.CreateNFT(
                wallet.Account,
                mintAccount,
                TokenStandard.NonFungible,
                data, true, false,
                MetadataVersion.V4,
                wallet.Account.PublicKey,
                wallet.Account,
                wallet.Account.PublicKey,
                wallet.Account.PublicKey,
                MetadataDelegateRole.Update,
                true
                );
            Console.WriteLine(tx.Result.RawRpcResponse);

            return tx.Result.Result == null ? string.Empty : tx.Result.Result;
        }
    }
}

