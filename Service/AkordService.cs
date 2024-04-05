using System;
using HelpSpace.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using RestSharp;
using RestSharp.Authenticators;

namespace HelpSpace.Service
{
    public interface IAkordService
    {
        Task<string> SaveFile(CreateNFTRequest createNFTRequest);
    }

    public class AkordService : IAkordService
    {

        readonly RestClient _client;

        public AkordService()
		{
            var options = new RestClientOptions("https://api.akord.com")
            {
                MaxTimeout = -1,
            };

            _client = new RestClient(options);
        }

        public async Task<string> SaveFile(CreateNFTRequest createNFTRequest)
        {

            ANFTManifestAttribute aNFTManifestAttribute = new ANFTManifestAttribute()
            {
                trait_type = "UDR",
                value = createNFTRequest.UDRHash
            };


            ANFTManifestAttribute aNFTManifestAttribute2 = new ANFTManifestAttribute()
            {
                trait_type = "Statut",
                value = createNFTRequest.StatutHash
            };


            ANFTManifestAttribute aNFTManifestAttribute3 = new ANFTManifestAttribute()
            {
                trait_type = "IndependentFinancialAudit",
                value = createNFTRequest.IndependentFinancialAuditHash
            };

            ANFTManifestAttribute aNFTManifestAttribute4 = new ANFTManifestAttribute()
            {
                trait_type = "CertificateOfNonProfitability",
                value = createNFTRequest.CertificateOfNonProfitabilityHash
            };

            NFTManifest nFTManifest = new NFTManifest {
                 name = $"HS_NFT_{createNFTRequest.Name}",
                 symbol = $"HS",
                 external_url = createNFTRequest.WebSite,
                 seller_fee_basis_points = 0,
                 description = createNFTRequest.Description,
                 mission = createNFTRequest.Mission,
                 socialLinks = createNFTRequest.SocialLinks,
                 attributes = new List<ANFTManifestAttribute>() { aNFTManifestAttribute, aNFTManifestAttribute2, aNFTManifestAttribute3, aNFTManifestAttribute4 }
            };




            var request = new RestRequest("/files", Method.Post);

            request.AddHeader("accept", "application/json");

            request.AddHeader("api-key", "QiTGa5V0qP9WOaeDObmor57mOQKtABcV1GC52bn9");

            request.AlwaysMultipartFormData = true;

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(nFTManifest);

            request.AddParameter("file", json);

            RestResponse response = await _client.ExecuteAsync(request);

            Console.WriteLine(response.Content);

            if (!response.IsSuccessful)
            {

            }

            return response.Content;
        }
    }
}

