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
            this._i = i;
            this._j = j;
            this._pattern = pattern;
        }

        public byte CountCellAliveNeighbors()
        {
            return CountAliveNeighbors(GetCurrentCellNeighbors());
        }

        private List<Cell> GetCurrentCellNeighbors()
        {
            List<Cell> neighbors = new List<Cell>();
            //walk through all cell neighbors
            for (int a = _i - 1; a <= _i + 1; a++)
            {
                // if neighbor is outside the matrix
                if (a < 0 || a >= _pattern.Size.Lenght)
                {
                    continue;
                }

                for (int b = _j - 1; b <= _j + 1; b++)
                {
                    //if neighor is outside the matrix
                    if (b < 0 || b >= _pattern.Size.Width)
                    {
                        continue;
                    }

                    if (a != _i || b != _j)
                    {
                        //add neighbor to list
                        neighbors.Add(_pattern.matrix[a][b]);
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