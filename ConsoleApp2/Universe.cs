using System;
using System.Collections.Generic;


namespace ConsoleApp2
{
    public class Universe
    {
        private Random _randomNum;

        public Universe()
        {
            _randomNum = new Random();
        }

        public void Init(Pattern pattern)
        {
            //randomly initialize the pattern
            for (int i = 0; i < pattern.matrix.Capacity; i++)
            {
                List<Cell> horizontalList = new List<Cell>(pattern.Size.Width);
                for (int j = 0; j < horizontalList.Capacity; j++)
                {
                    Cell cell = new Cell();                    
                    cell.Status = RandomBoolValue() ? CellStatuses.Alive : CellStatuses.Dead;
                    horizontalList.Add(cell);
                }
                pattern.matrix.Add(horizontalList);
            }
        }

        public void Evolve(Pattern pattern)
        {
            //parse each cell
            for (int i = 0; i < pattern.matrix.Capacity; i++)
            {
                for (int j = 0; j < pattern.Size.Width; j++)
                {
                    byte aliveNeighbors = new CellCounter(i, j, pattern).CountCellAliveNeighbors();
                    //cell status change based on alive neighbors and status
                    pattern.matrix[i][j].Status = new GameRules().GetNewCellStatus(aliveNeighbors, pattern.matrix[i][j].Status);
                }
            }
        }        
        
        private bool RandomBoolValue()
        {
            return _randomNum.NextDouble() >= 0.5 ? true : false;
        }
    }
}