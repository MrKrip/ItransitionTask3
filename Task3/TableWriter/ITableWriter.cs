using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Rules;

namespace Task3.TableWriter
{
    abstract class ITableWriter
    {
        public ITableWriter(IRule GameRule) { }
        public abstract void PrintTable();
    }
}
