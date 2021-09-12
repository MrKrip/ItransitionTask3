using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Rules
{
    class DefaultRule : IRule
    {
        public int[,] RulesTable { get; private set; }

        public void SetRules(string[] args)
        {
            RulesTable = new int[args.Length, args.Length];
            int Steps = args.Length / 2;
            for(int i=0;i<args.Length; i++)
            {                
                RulesTable[i, i] = 0;
                int temp = i;
                for (;Steps>0;Steps--)
                {                    
                    if(temp+1<args.Length)
                    {
                        RulesTable[i, ++temp] = 1;
                    }
                    else
                    {
                        temp = 0;
                        RulesTable[i, temp] = 1;
                    }
                }
                temp = i;
                for (;Steps<(int)args.Length/2;Steps++)
                {                    
                    if(temp-1<0)
                    {
                        temp = args.Length - 1;
                        RulesTable[i, temp] = -1;
                    }
                    else
                    {
                         RulesTable[i, --temp] = -1;
                    }
                }
            }
        }

        public void PrintTable()
        {
            int n = (int)Math.Sqrt(RulesTable.Length);
            for(int i=0;i<n;i++)
            {
                for(int j=0;j<n;j++)
                {
                    Console.Write($"\t{RulesTable[i,j]}");
                }
                Console.WriteLine();
            }
        }
    }
}
