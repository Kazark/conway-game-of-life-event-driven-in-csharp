using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core.Events
{
    public class CellDied : Event
    {
        public PositionInGrid location { get; set; }
    }
}
