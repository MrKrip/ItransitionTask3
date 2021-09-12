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
        private string[] UniqueItems;
        public Game(IRule Rule,IGameKey gameKey,ITableWriter tableWriter)
        {
            this.GameRule = Rule;
            this.GameKey = gameKey;
            this.tableWriter = tableWriter;
        }

        public void Start(string[] args)
        {
            string[] uniqueItems = args.Select(x=>x.ToLower()).Distinct<string>().ToArray();
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            UniqueItems = uniqueItems.Select(x => textInfo.ToTitleCase(x)).ToArray();

            GameRule.SetRules(UniqueItems);

            HMAC = GameKey.GenerateHMAC();
            string HMACString = BitConverter.ToString(HMAC).Replace("-", string.Empty);

            string input = string.Empty;
            while(input!="0")
            {
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
                    tableWriter.PrintTable(GameRule);
                }else if(Int32.TryParse(input,out n))
                {
                    if (n<1||n> UniqueItems.Length)
                    {
                        continue;
                    }
                    else
                    {
                        GameProgress(Int32.Parse(input)-1);
                    }
                }
                Console.WriteLine(new string('-', 80));
            }
        }

        private void GameProgress(int Player)
        {
            Random rng = new Random();
            int Computer = rng.Next(0,UniqueItems.Length-1);
            Console.WriteLine($"Your move: {UniqueItems[Player]}\nComputer move: {UniqueItems[Computer]}");
            int Result = GameRule.RulesTable[Player, Computer];
            if(Result==0)
            {
                Console.WriteLine("DRAW");
            }else if(Result>0)
            {
                Console.WriteLine("You Win");
            }else if(Result<0)
            {
                Console.WriteLine("You Lose");
            }
        }
    }
}
