using System;
using System.Collections.Generic;



namespace ConsoleApp2
{
    public partial class Pattern
    {
        public readonly PatternSize Size;
        public List<List<Cell>> matrix;


        public Pattern(PatternSize size)
        {
            Size = size;
            matrix = new List<List<Cell>>(Size.Lenght);
        }
    }
}
        

      