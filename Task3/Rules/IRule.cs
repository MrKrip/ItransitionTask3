using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Rules
{
    interface IRule
    {
        public string[,] RulesTable { get; }
        public void SetRules(String[] args);
    }
}
