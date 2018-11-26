using System.Collections.Generic;

public partial class Cell
{
    private CellStatuses _status;
    
    public CellStatuses Status { get => _status; set => _status = value; }


    public void SetCellStatus(Cell cell, bool status)
    {
        if (status)
        {
            cell.Status = CellStatuses.Alive;
        }
        else
        {
            cell.Status = CellStatuses.Dead;
        }
    }

}