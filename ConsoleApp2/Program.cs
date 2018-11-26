using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp2
{
    internal partial class Program
    {
        private static void Main(string[] args)
        {
            Pattern pattern = new Pattern(new Pattern.PatternSize(20,10));
            var abc = new ProgramGenerator();
            abc.RandomPopulatePattern(pattern);

            Printer printer = new Printer();
                       

            while (true)
            {
                printer.PrintPattern(pattern);
                abc.EvolvePattern(pattern);               
                Thread.Sleep(500);
                Console.Clear();
            }
        }
    }
}