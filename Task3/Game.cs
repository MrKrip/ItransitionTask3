using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Rules;

namespace Task3
{
    class Game
    {
        private IRule GameRule;
        public Game(IRule Rule)
        {
            this.GameRule = Rule;
        }
    }
}
