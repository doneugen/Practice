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
            //parse each cell
            for (int i = 0; i < pattern.matrix.Capacity; i++)
            {
                for (int j = 0; j < pattern.Size.Width; j++)
                {
                    CellCounter cellCounter = new CellCounter();
                    byte aliveNeighbors = cellCounter.CountCellAliveNeighbors(pattern, i, j);
                    //cell status change based on alive neighbors and status
                    pattern.matrix[i][j].Status = GetCellStatusBasedOnGameRules(aliveNeighbors, pattern.matrix[i][j].Status);
                }
            }
        }             

        public CellStatuses GetCellStatusBasedOnGameRules(byte numberOfLiveNeighbors, CellStatuses status)
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