using System.Collections.Generic;
using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core.Events
{
    public class GenerationComputed : Event
    {
        public IEnumerable<Cell<bool>> grid { get; set; }
    }
}
