﻿using System;
using Task3.Rules;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            IRule test = new DefaultRule();
            test.SetRules(args);
            test.PrintTable();
        }
    }
}