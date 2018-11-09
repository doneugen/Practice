using System.Collections.Generic;



namespace ConsoleApp2
{
    internal partial class Program
    {
        private static void Main(string[] args)
        {
            char deadCellNotation = ' ';
            char aliveCellNotation = '*';

            Matrix matrix = new Matrix(10, 10);

            ////Initial board randomized
            matrix.Initialize(deadCellNotation, aliveCellNotation);

            while (true)
            {
                matrix.Print();

                List<List<char>> neighbors = matrix.GetNeighboursNonPrimitive();

                matrix.RecalculateMatrix(neighbors, deadCellNotation, aliveCellNotation);
            }
        }
    }
}