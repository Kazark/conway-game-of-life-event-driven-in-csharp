using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core.Events
{
    public class OneGenerationOfCellStatesAggregated : Event
    {
        public Grid<bool> grid { get; set; }
    }
}
