using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Rules
{
    class DefaultRule : IRule
    {
        public string[,] RulesTable { get; private set; }

        public void SetRules(string[] args)
        {
            RulesTable = new string[args.Length, args.Length];
            int Steps = args.Length / 2;
            for(int i=0;i<args.Length; i++)
            {                
                RulesTable[i, i] = "Draw";
                int temp = i;
                for (;Steps>0;Steps--)
                {                    
                    if(temp+1<args.Length)
                    {
                        RulesTable[i, ++temp] = "Win";
                    }
                    else
                    {
                        temp = 0;
                        RulesTable[i, temp] = "Win";
                    }
                }
                temp = i;
                for (;Steps<(int)args.Length/2;Steps++)
                {                    
                    if(temp-1<0)
                    {
                        temp = args.Length - 1;
                        RulesTable[i, temp] = "Lose";
                    }
                    else
                    {
                         RulesTable[i, --temp] = "Lose";
                    }
                }
            }
        }
    }
}
