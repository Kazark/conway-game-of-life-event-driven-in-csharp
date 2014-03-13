using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core.Events
{
    public class GameInitiated : Event
    {
        public Grid<bool> grid { get; set; }
    }
}
