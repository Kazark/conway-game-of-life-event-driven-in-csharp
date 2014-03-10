using GameOfLife.Core.Events;
using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core.Handlers
{
    public class DetermineNextStateOfDeadCell : IConsume<LivingNeighborsOfDeadCellCounted>
    {
        public void Consume(LivingNeighborsOfDeadCellCounted eventData)
        {
            throw new System.NotImplementedException();
        }
    }
}
