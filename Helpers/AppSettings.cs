using System;
namespace HelpSpace.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }

        public int RefreshTokenTTL { get; set; }
        public int LifeTimeJWTTokenMinutes { get; set; }

        public string ProdMnemonicWords { get; set; }

    }
}

