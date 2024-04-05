using System;
namespace HelpSpace.Models
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ANFTManifestAttribute
    {
        public string trait_type { get; set; }
        public string value { get; set; }
    }

    public class NFTManifestCreator
    {
        public string address { get; set; }
        public bool verified { get; set; }
        public int share { get; set; }
    }

    public class NFTManifestFile
    {
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class NFTManifestProperties
    {
        public string category { get; set; }
        public List<NFTManifestCreator> creators { get; set; }
        public List<NFTManifestFile> files { get; set; }
    }

    public class NFTManifest
    {
        public string name { get; set; }
        public string symbol { get; set; }
        public string description { get; set; }
        public string mission { get; set; }
        public string socialLinks { get; set; }
        public int seller_fee_basis_points { get; set; }
   //     public string image { get; set; }
  //      public object animation_url { get; set; }
        public List<ANFTManifestAttribute> attributes { get; set; }
        public string external_url { get; set; }
  //      public NFTManifestProperties properties { get; set; }
    }


//    public string Mission { get; set; }


//    public string SolanaKey { get; set; }
//    public string SocialLinks { get; set; }

//    public string UDRHash { get; set; }
//    public string StatutHash { get; set; }
 //   public string IndependentFinancialAuditHash { get; set; }
 //   public string CertificateOfNonProfitabilityHash { get; set; }

}

