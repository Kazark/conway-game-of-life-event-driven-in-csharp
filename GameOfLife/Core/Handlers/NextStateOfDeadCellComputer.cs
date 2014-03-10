using GameOfLife.Core.Events;
using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core.Handlers
{
    class NextStateOfDeadCellComputer : IConsume<LivingNeighborsOfDeadCellCounted>
    {
        public void Consume(LivingNeighborsOfDeadCellCounted eventData)
        {
            throw new System.NotImplementedException();
        }
    }
}
