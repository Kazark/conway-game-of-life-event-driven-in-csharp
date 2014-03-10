using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core.Events
{
    public class LivingNeighborsOfLiveCellCounted : Event
    {
        public PositionInGrid position { get; set; }
        public int livingNeighbors { get; set; }
    }
}
