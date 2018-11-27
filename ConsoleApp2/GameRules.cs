namespace ConsoleApp2
{
    internal class GameRules
    {
        public CellStatuses GetNewCellStatus(byte numberOfLiveNeighbors, CellStatuses status)
        {

            if (status == CellStatuses.Alive)
            {
                return GetNewStatusIfOldStatusIsAlive(numberOfLiveNeighbors);
            }
            else
            {
                return GetNewStatusIfOldStatusIsDead(numberOfLiveNeighbors);
            }
        }

        private CellStatuses GetNewStatusIfOldStatusIsAlive(byte numberOfLiveNeighbors)
        {
            if (numberOfLiveNeighbors == 2 || numberOfLiveNeighbors == 3)
            {
                return CellStatuses.Alive;
            }
            return CellStatuses.Dead;
        }

        private CellStatuses GetNewStatusIfOldStatusIsDead(byte numberOfLiveNeighbors)
        {
            if (numberOfLiveNeighbors == 3)
            {
                return CellStatuses.Alive;
            }
            return CellStatuses.Dead;
        }

    }
}
