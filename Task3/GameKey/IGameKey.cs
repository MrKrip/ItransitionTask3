using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.GameKey
{
    interface IGameKey
    {
        public byte[] GenerateHMAC();
        public byte[] GenerateHMACKey(byte[] HMAC,int key);
    }
}
