using System;
using System.Collections.Generic;


namespace ConsoleApp2
{
    public class ProgramGenerator
    {
        private Random _randomNum;
        public ProgramGenerator()
        {
            _randomNum = new Random();
        }

        public void RandomPopulatePattern(Pattern pattern)
        {
            for (int i = 0; i < pattern.matrix.Capacity; i++)
            {
                List<Cell> horizontalList = new List<Cell>(pattern.Size.Width);
                for (int j = 0; j < horizontalList.Capacity; j++)
                {
                    Cell cell = new Cell();
                    cell.SetCellStatus(cell, GetRandomBoolValue());
                    horizontalList.Add(cell);
                }
                pattern.matrix.Add(horizontalList);
            }
        }

        private bool GetRandomBoolValue()
        {
            if (_randomNum.NextDouble() >= 0.5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public void EvolvePattern(Pattern pattern)
        {
            for (int i = 0; i < pattern.matrix.Capacity; i++)
            {
                for (int j = 0; j < pattern.Size.Width; j++)
                {
                    byte liveNeighbors = CountCellAliveNeighbors(pattern, i, j);
                    pattern.matrix[i][j].Status = EvolveCellBasedOnLiveNeighborsAndStatus(liveNeighbors, pattern.matrix[i][j].Status);
                }
            }
        }

        public byte CountCellAliveNeighbors(Pattern pattern, int i, int j)
        {
            List<Cell> neighbors = CountNeighborsForCurrentCell(pattern, i, j);
            return CountAliveNeighbors(neighbors);

        }

        public List<Cell> CountNeighborsForCurrentCell(Pattern pattern, int i, int j)
        {
            List<Cell> neighbors = new List<Cell>();

            for (int a = i - 1; a <= i + 1; a++)
            {
                if (a < 0 || a >= pattern.Size.Lenght)
                {
                    continue;
                }

                for (int b = j - 1; b <= j + 1; b++)
                {
                    if (b < 0 || b >= pattern.Size.Width)
                    {
                        continue;
                    }

                    if (a != i || b != j)
                    {
                        neighbors.Add(pattern.matrix[a][b]);
                    }
                }
            }
            return neighbors;
        }

        public byte CountAliveNeighbors(List<Cell> cells)
        {
            byte iteration = 0;

            foreach (Cell cell in cells)
            {
                if (cell.Status == CellStatuses.Alive)
                { iteration++; }
            }
            return iteration;
        }

        public CellStatuses EvolveCellBasedOnLiveNeighborsAndStatus(byte numberOfLiveNeighbors, CellStatuses status)
        {

            if (status == CellStatuses.Alive)
            {
                if (numberOfLiveNeighbors < 2)
                {
                    return CellStatuses.Dead;
                }

                if (numberOfLiveNeighbors == 2 || numberOfLiveNeighbors == 3)
                {
                    return CellStatuses.Alive;
                }

                if (numberOfLiveNeighbors > 3)
                {
                    return CellStatuses.Dead;
                }
            }

            if (status == CellStatuses.Dead && numberOfLiveNeighbors == 3)
            {
                return CellStatuses.Alive;
            }

            return CellStatuses.Dead;
        }
    }
}