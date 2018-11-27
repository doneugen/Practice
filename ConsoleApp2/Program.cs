using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp2
{
    internal partial class Program
    {
        private static void Main(string[] args)
        {
            Pattern pattern = new Pattern(new Pattern.PatternSize(40));

            var sp25 = new Universe();
            sp25.InitPattern(pattern);

            Printer printer = new Printer();                       

            while (true)
            {
                printer.PrintPattern(pattern);
                sp25.EvolvePattern(pattern);               
                Thread.Sleep(250);
                Console.Clear();
            }
        }
    }
}