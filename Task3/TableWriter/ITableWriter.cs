using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Rules;

namespace Task3.TableWriter
{
    interface ITableWriter
    {
        public void PrintTable(IRule GameRule, string[] UniqueItems);
    }
}
