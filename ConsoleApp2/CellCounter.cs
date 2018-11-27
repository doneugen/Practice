using System.Collections.Generic;


namespace ConsoleApp2
{
    public class CellCounter
    {
        private readonly int _i;
        private readonly int _j;
        private readonly Pattern _pattern;

        public CellCounter(int i, int j, Pattern pattern)
        {
            _i = i;
            _j = j;
            _pattern = pattern;
        }

        public byte CountCellAliveNeighbors()
        {
            return CountAliveNeighbors(GetCurrentCellNeighbors(_pattern, _i, _j));
        }

        private List<Cell> GetCurrentCellNeighbors(Pattern pattern, int i, int j)
        {
            List<Cell> neighbors = new List<Cell>();
            //walk through all cell neighbors
            for (int a = i - 1; a <= i + 1; a++)
            {
                // if neighbor is outside the matrix
                if (a < 0 || a >= pattern.Size.Lenght)
                {
                    continue;
                }

                for (int b = j - 1; b <= j + 1; b++)
                {
                    //if neighor is outside the matrix
                    if (b < 0 || b >= pattern.Size.Width)
                    {
                        continue;
                    }

                    if (a != i || b != j)
                    {
                        //add neighbor to list
                        neighbors.Add(pattern.matrix[a][b]);
                    }
                }
            }
            return neighbors;
        }

        private byte CountAliveNeighbors(List<Cell> cellsList)
        {
            byte iteration = 0;

            foreach (Cell cell in cellsList)
            {
                if (cell.Status == CellStatuses.Alive)
                {
                    iteration++;
                }
            }
            return iteration;
        }

    }
}