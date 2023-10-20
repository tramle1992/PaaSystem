using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;
using System.Security.Cryptography;

namespace Common.Infrastructure.Encryption
{
    public class MD5EncryptionService : IEncryptionService
    {
        public string EncryptedValue(string plainTextValue)
        {
            AssertionConcern.AssertArgumentNotEmpty(plainTextValue, "Plain text value to encrypt must be provided");

            var encryptedValue = new StringBuilder();

            var hasher = MD5.Create();

            var data = hasher.ComputeHash(Encoding.Default.GetBytes(plainTextValue));

            for (int dataIndex = 0; dataIndex < data.Length; dataIndex++)
            {
                encryptedValue.Append(data[dataIndex].ToString("x2"));
            }

            return encryptedValue.ToString();
        }
    }
}
