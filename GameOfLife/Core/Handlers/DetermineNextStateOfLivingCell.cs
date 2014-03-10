using GameOfLife.Core.Events;
using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core.Handlers
{
    public class DetermineNextStateOfLivingCell : IConsume<LivingNeighborsOfLiveCellCounted>
    {
        public void Consume(LivingNeighborsOfLiveCellCounted eventData)
        {
            throw new System.NotImplementedException();
        }
    }
}
