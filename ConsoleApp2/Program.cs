using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            int[,] initialMatrix = new int[,] {{ 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                                               { 0, 0, 1, 0, 0, 0, 0, 1, 1, 1},
                                               { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
                                               { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                               { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                               { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                               { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                               { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                                               { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0}};

            while (true)
            {
                PrintMatrix(initialMatrix);

                List<List<int>> neighbors = GetNeighborsNonPrimitive(initialMatrix);

                RecalculateMatrix(initialMatrix, neighbors);

            }
        }


        public static void PrintMatrix(int[,] matrix)
        {
            int rowLenght = matrix.GetLength(0);
            int columnLenght = matrix.GetLength(1);

            Console.WriteLine("Print the matrix :");
            for (int i = 0; i < rowLenght; i++)
            {
                for (int j = 0; j < columnLenght; j++)
                {
                    Console.Write(" " + matrix[i, j]);
                }
                Console.WriteLine("");
            }

            System.Threading.Thread.Sleep(500);
            Console.Clear();
        }

        public static List<List<int>> GetNeighborsNonPrimitive(int[,] matrix)
        {

            List<List<int>> neighbors = new List<List<int>>();


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    List<int> list = new List<int>();
                    for (int a = i - 1; a <= i + 1; a++)
                    {
                        if (a < 0 || a >= matrix.GetLength(0))
                        {
                            continue;
                        }

                        for (int b = j - 1; b <= j + 1; b++)
                        {
                            if (b < 0 || b >= matrix.GetLength(1))
                            {
                                continue;
                            }

                            if (a != i || b != j)
                            {
                                list.Add(matrix[a, b]);
                            }
                        }

                    }
                    neighbors.Add(list);
                }

            }

            return neighbors;
        }

        public static List<int> CountLiveCells(List<List<int>> neighbors)
        {
            List<int> liveCellsList = new List<int>();

            //get for each array in list the numbers of 1 values
            foreach (List<int> n in neighbors)
            {
                liveCellsList.Add(n.FindAll(x => x == 1).Count);
            }

            return liveCellsList;
        }

        public static void RecalculateMatrix(int[,] matrix, List<List<int>> neighbors)
        {
            List<int> liveCells = CountLiveCells(neighbors);
            int[,] updatedMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            int incr = 0;


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    //cell birth
                    if (liveCells[incr] == 3)
                    {
                        matrix[i, j] = 1;
                    }

                    //cell death
                    if (liveCells[incr] < 2 || liveCells[incr] > 3)
                    {
                        matrix[i, j] = 0;
                    }

                    incr++;
                }
            }
        }
    }
}

