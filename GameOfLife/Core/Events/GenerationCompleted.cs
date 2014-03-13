using System.Collections.Generic;
using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core.Events
{
    public class GenerationCompleted : Event
    {
        public IEnumerable<Cell<bool>> grid { get; set; }
    }
}
