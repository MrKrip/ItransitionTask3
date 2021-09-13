using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Rules;

namespace Task3.TableWriter
{
    class DefaultTableWriter : ITableWriter
    {

        public void PrintTable(IRule GameRule, string[] UniqueItems)
        {
            string[] temp = new string[UniqueItems.Length+1];
            temp[0] = "User/PC";
            UniqueItems.CopyTo(temp, 1);
            var table = new ConsoleTable(temp);
            for (int i=0;i<UniqueItems.Length;i++)
            {
                temp = new string[UniqueItems.Length + 1];
                temp[0] = UniqueItems[i];
                for (int j=0;j<UniqueItems.Length;j++)
                {
                    temp[j + 1] = GameRule.RulesTable[i, j];
                }
                table.AddRow(temp);
            }
            table.Write();
        }
    }
}
