using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core.Events
{
    public class LivingNeighborsOfDeadCellCounted : Event
    {
        public PositionInGrid position { get; set; }
        public int livingNeighbors { get; set; }
    }
}
