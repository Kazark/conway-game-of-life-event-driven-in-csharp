using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core.Events
{
    class CellDied : Event
    {
        public PositionInGrid location { get; set; }
    }
}
