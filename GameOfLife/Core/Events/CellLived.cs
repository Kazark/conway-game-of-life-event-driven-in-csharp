using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core.Events
{
    public class CellLived : Event
    {
        public PositionInGrid location { get; set; }
    }
}
