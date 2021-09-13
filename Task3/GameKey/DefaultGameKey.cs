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

        public byte[] GenerateHMACKey(byte[] HMAC, int key)
        {            
            using (var hmac = new HMACSHA256(HMAC))
            {                
                var bhash = hmac.ComputeHash(BitConverter.GetBytes(key));
                return bhash;
            }
        }
    }
}
