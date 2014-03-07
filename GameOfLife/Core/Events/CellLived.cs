using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core.Events
{
    class CellLived : Event
    {
        public PositionInGrid location { get; set; }
    }
}
