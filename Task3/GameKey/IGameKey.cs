using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.GameKey
{
    interface IGameKey
    {
        public string GenerateHMAC();
        public string GenerateHMACKey();
    }
}
