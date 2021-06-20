using EntityFrameworkCore.DataProtection.Encryption.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.DataProtection.Example.Web.Data.Entity
{
    public class EncryptExample
    {
        public EncryptExample() { }
        public EncryptExample(string deger)
        {
            EncryptArea = deger;
            CleanArea = deger;
        }

        public Guid UUID { get; set; }

        [EncryptColumn]
        public string EncryptArea { get; set; }
        public string CleanArea { get; set; }
    }
}
