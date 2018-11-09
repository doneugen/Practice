using System;
using System.Collections.Generic;



namespace ConsoleApp2
{
    internal partial class Program
    {
        public class Matrix
        {
            private readonly int _matrixRows;
            private readonly int _matrixColumns;
            private readonly char[,] initialMatrix;

            public Matrix(int rows, int columns)
            {
                _matrixRows = rows;
                _matrixColumns = columns;

                initialMatrix = new char[_matrixRows, _matrixColumns];
            }


            public void Initialize(char x, char y)
            {
                Random randomNum = new Random();

                for (int i = 0; i < _matrixRows; i++)
                {
                    for (int j = 0; j < _matrixColumns; j++)
                    {
                        if (randomNum.NextDouble() >= 0.5)
                        {
                            initialMatrix[i, j] = x;
                        }
                        else
                        {
                            initialMatrix[i, j] = y;
                        }
                    }
                }


            }

            public void Print()
            {

                Console.WriteLine("Print the matrix :");
                for (int i = 0; i < _matrixRows; i++)
                {
                    for (int j = 0; j < _matrixColumns; j++)
                    {
                        Console.Write(" " + initialMatrix[i, j]);
                    }
                    Console.WriteLine("");
                }

                System.Threading.Thread.Sleep(500);
                Console.Clear();
            }

            public List<List<char>> GetNeighboursNonPrimitive()
            {

                List<List<char>> neighbors = new List<List<char>>();


                for (int i = 0; i < _matrixRows; i++)
                {
                    for (int j = 0; j < _matrixColumns; j++)
                    {
                        List<char> list = new List<char>();
                        for (int a = i - 1; a <= i + 1; a++)
                        {
                            if (a < 0 || a >= _matrixRows)
                            {
                                continue;
                            }

                            for (int b = j - 1; b <= j + 1; b++)
                            {
                                if (b < 0 || b >= _matrixColumns)
                                {
                                    continue;
                                }

                                if (a != i || b != j)
                                {
                                    list.Add(initialMatrix[a, b]);
                                }
                            }

                        }
                        neighbors.Add(list);
                    }

                }

                return neighbors;
            }

            public void RecalculateMatrix(List<List<char>> neighbors, char dead, char alive)
            {
                List<int> liveCells = CountLiveCells(neighbors, alive);
                char[,] updatedMatrix = new char[_matrixRows, _matrixColumns];
                int incr = 0;


                for (int i = 0; i < _matrixRows; i++)
                {
                    for (int j = 0; j < _matrixColumns; j++)
                    {
                        //cell birth
                        if (liveCells[incr] == 3)
                        {
                            initialMatrix[i, j] = alive;
                        }

                        //cell death
                        if (liveCells[incr] < 2 || liveCells[incr] > 3)
                        {
                            initialMatrix[i, j] = dead;
                        }

                        incr++;
                    }
                }
            }

            public List<int> CountLiveCells(List<List<char>> neighbors, char alive)
            {
                List<int> liveCellsList = new List<int>();

                //get for each array in list the alive cells
                foreach (List<char> n in neighbors)
                {

                    liveCellsList.Add(n.FindAll(x => x == alive).Count);
                }

                return liveCellsList;
            }


        }
    }
}





//1.Make 1/0 in matrix to be x/y or any other symbol
//2. Separate to class