using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Task3.GameKey;
using Task3.Rules;
using Task3.TableWriter;

namespace Task3
{
    class Game
    {
        private IRule GameRule;
        private IGameKey GameKey;
        private ITableWriter tableWriter;
        private byte[] HMAC;
        private byte[] HMACKey;
        private string[] UniqueItems;
        public Game(IRule Rule,IGameKey gameKey,ITableWriter tableWriter)
        {
            this.GameRule = Rule;
            this.GameKey = gameKey;
            this.tableWriter = tableWriter;
        }

        public void Start(string[] args)
        {
            SelectUniqueItems(args);
            if(UniqueItems.Length<3 || (UniqueItems.Length % 2) == 0)
            {
                Console.WriteLine("There must be at least 3 unique items and the number of items must be odd.\nFor example : rock paper scissors");
                return;
            }

            GameRule.SetRules(UniqueItems);

            HMAC = GameKey.GenerateHMAC();
            string HMACString = BitConverter.ToString(HMAC).Replace("-", string.Empty);
           

            string input = string.Empty;
            while(input!="0")
             {  
                int Computer = RandomNumberGenerator.GetInt32(0, UniqueItems.Length -1 );
                HMACKey = GameKey.GenerateHMACKey(HMAC,Computer);
                Console.WriteLine(new string('-', 80));
                Console.WriteLine($"HMAC:\n{HMACString}");
                for(int i=0;i< UniqueItems.Length; i++)
                {
                    Console.WriteLine($"{i+1} - {UniqueItems[i]}");
                }
                Console.WriteLine("0 - exit\n? - help");
                Console.Write("Enter your move: ");
                input = Console.ReadLine();
                int n;
                if(input=="?")
                {
                    tableWriter.PrintTable(GameRule,UniqueItems);
                }else if(Int32.TryParse(input,out n))
                {
                    if (n<1||n> UniqueItems.Length)
                    {
                        continue;
                    }
                    else
                    {
                        GameProgress(Int32.Parse(input)-1,Computer);
                    }
                }                
            }
        }

        private void GameProgress(int Player,int Computer)
        {           
            
            Console.WriteLine($"Your move: {UniqueItems[Player]}\nComputer move: {UniqueItems[Computer]}");
            string Result = GameRule.RulesTable[Player, Computer];
            Console.WriteLine($"You {Result}");
            Console.WriteLine($"HMAC key : {BitConverter.ToString(HMACKey).Replace("-", string.Empty)}");
        }

        private void SelectUniqueItems(string[] args)
        {
            string[] uniqueItems = args.Select(x => x.ToLower()).Distinct<string>().ToArray();
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            UniqueItems = uniqueItems.Select(x => textInfo.ToTitleCase(x)).ToArray();
        }


    }
}
