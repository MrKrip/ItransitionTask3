using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Task3.GameKey
{
    class DefaultGameKey : IGameKey
    {
        public byte[] GenerateHMAC()
        {
            byte[] random = new byte[16];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(random);
            return random;
        }

        public byte[] GenerateHMACKey()
        {
            throw new NotImplementedException();
        }
    }
}
