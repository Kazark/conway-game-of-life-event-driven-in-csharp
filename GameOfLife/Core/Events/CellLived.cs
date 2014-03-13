using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core.Events
{
    public class CellLived : Event
    {
        public CellLived()
        {
            position = new PositionInGrid();
        }

        public CellLived(int row, int column)
        {
            position = new PositionInGrid(row, column);
        }

        public PositionInGrid position { get; set; }
    }
}
