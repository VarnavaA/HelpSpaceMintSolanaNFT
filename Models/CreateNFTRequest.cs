using System;
using Microsoft.VisualBasic;

namespace HelpSpace.Models
{
	public class CreateNFTRequest
	{
        public string Name { get; set; }
        public string Mission { get; set; }
        public string Description { get; set; }
        public string WebSite { get; set; }
        public string SolanaKey { get; set; }
        public string SocialLinks { get; set; }

        public string UDRHash { get; set; } 
        public string StatutHash { get; set; }
        public string IndependentFinancialAuditHash { get; set; } 
        public string CertificateOfNonProfitabilityHash { get; set; } 
    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class SaveNFTResponceCloud
    {
        public string uri { get; set; }
        public string url { get; set; }
    }

    public class SaveNFTResponce
    {
        public string id { get; set; }
        public string mimeType { get; set; }
        public int sizeInBytes { get; set; }
        public SaveNFTResponceCloud cloud { get; set; }
        public SaveNFTResponceTx tx { get; set; }
    }

    public class SaveNFTResponceTx
    {
        public string id { get; set; }
        public string status { get; set; }
        public List<object> tags { get; set; }
        public string statusUrl { get; set; }
        public List<string> gatewayUrls { get; set; }
        public string viewblockUrl { get; set; }
        public string info { get; set; }
        public string infoUrl { get; set; }
    }


    public class NFTResponce
    {
        public string jsonrpc { get; set; }
        public string result { get; set; }
        public int id { get; set; }
    }







    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class TransactionInfoHeader
    {
        public int numReadonlySignedAccounts { get; set; }
        public int numReadonlyUnsignedAccounts { get; set; }
        public int numRequiredSignatures { get; set; }
    }

    public class TransactionInfoInnerInstruction
    {
        public int index { get; set; }
        public List<TransactionInfoInstruction> instructions { get; set; }
    }

    public class TransactionInfoInstruction
    {
        public List<int> accounts { get; set; }
        public string data { get; set; }
        public int programIdIndex { get; set; }
        public int stackHeight { get; set; }
    }

    public class TransactionInfoLoadedAddresses
    {
        public List<object> @readonly { get; set; }
        public List<object> writable { get; set; }
    }

    public class TransactionInfoMessage
    {
        public List<string> accountKeys { get; set; }
        public TransactionInfoHeader header { get; set; }
        public List<TransactionInfoInstruction> instructions { get; set; }
        public string recentBlockhash { get; set; }
    }

    public class TransactionInfoMeta
    {
        public int computeUnitsConsumed { get; set; }
        public object err { get; set; }
        public int fee { get; set; }
        public List<TransactionInfoInnerInstruction> innerInstructions { get; set; }
        public TransactionInfoLoadedAddresses loadedAddresses { get; set; }
        public List<string> logMessages { get; set; }
        public List<long> postBalances { get; set; }
        public List<TransactionInfoPostTokenBalance> postTokenBalances { get; set; }
        public List<long> preBalances { get; set; }
        public List<object> preTokenBalances { get; set; }
        public List<object> rewards { get; set; }
        public TransactionInfoStatus status { get; set; }
    }

    public class TransactionInfoPostTokenBalance
    {
        public int accountIndex { get; set; }
        public string mint { get; set; }
        public string owner { get; set; }
        public string programId { get; set; }
        public TransactionInfoUiTokenAmount uiTokenAmount { get; set; }
    }

    public class TransactionInfoResult
    {
        public int blockTime { get; set; }
        public TransactionInfoMeta meta { get; set; }
        public int slot { get; set; }
        public TransactionInfoTransaction transaction { get; set; }
    }

    public class TransactionInfo
    {
        public string jsonrpc { get; set; }
        public TransactionInfoResult result { get; set; }
        public int id { get; set; }
    }

    public class TransactionInfoStatus
    {
        public object Ok { get; set; }
    }

    public class TransactionInfoTransaction
    {
        public TransactionInfoMessage message { get; set; }
        public List<string> signatures { get; set; }
    }

    public class TransactionInfoUiTokenAmount
    {
        public string amount { get; set; }
        public int decimals { get; set; }
        public double uiAmount { get; set; }
        public string uiAmountString { get; set; }
    }


}

