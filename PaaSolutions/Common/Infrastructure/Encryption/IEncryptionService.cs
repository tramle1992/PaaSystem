using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure.Encryption
{
    public interface IEncryptionService
    {
        string EncryptedValue(string plainTextValue);
    }
}
