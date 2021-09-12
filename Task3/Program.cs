using System;
using Task3.GameKey;
using Task3.Rules;
using Task3.TableWriter;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Game TestGame = new Game(new DefaultRule(),new DefaultGameKey(),new DefaultTableWriter());
            TestGame.Start(args);
        }
    }
}
