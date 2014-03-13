using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core.Events
{
    public class CellDied : Event
    {
        public CellDied()
        {
            position = new PositionInGrid();
        }

        public CellDied(int row, int column)
        {
            position = new PositionInGrid(row, column);
        }

        public PositionInGrid position { get; set; }
    }
}
