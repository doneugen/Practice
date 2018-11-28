using System.Collections.Generic;

public partial class Cell
{
    private CellStatuses _status;
    
    public CellStatuses Status { get => _status; set => _status = value; }
}