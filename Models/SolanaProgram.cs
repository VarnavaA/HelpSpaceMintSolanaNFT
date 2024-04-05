using Solnet.Programs.Utilities;
using Solnet.Rpc.Builders;
using Solnet.Rpc.Models;
using Solnet.Wallet;
using Solnet.Wallet.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpSpace.Models
{
	public static class SolanaProgram
	{

        public static TransactionInstruction NewSolanaProgram( string jsonString, PublicKey account, PublicKey ProgramIdKey)
        {

            List<AccountMeta> keys = new();

            if (account != null)
            {
                keys.Add(AccountMeta.Writable(account, false));
            }
          

            byte[] memoBytes = Encoding.UTF8.GetBytes(jsonString);

            return new TransactionInstruction
            {
                ProgramId = ProgramIdKey.KeyBytes,
                Keys = keys,
                Data = memoBytes
            };
        }
    }

    public class SolanaBody
    {
        public string instruction { get; set; }
        public string customer_id { get; set; }
        public string legal_name { get; set; }
        public string registration_number { get; set; }
        public string incorporation_country { get; set; }
        public string lei_registration_status { get; set; }
        public string lei { get; set; }
        public string incorporation_date { get; set; }
        public string primary_country_operation { get; set; }
        public string primary_isic_code { get; set; }
        public string entity_type { get; set; }
        public string swift_code { get; set; }
        public bool kyc_status { get; set; }
        public bool is_active { get; set; }
    }
}

