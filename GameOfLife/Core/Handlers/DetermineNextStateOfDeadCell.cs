using GameOfLife.Core.Events;
using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core.Handlers
{
    public class DetermineNextStateOfDeadCell : IConsume<LivingNeighborsOfDeadCellCounted>
    {
        private readonly IConsume<CellLived> _cellLivedChannel;
        private readonly IConsume<CellDied> _cellDiedChannel;

        public DetermineNextStateOfDeadCell(IConsume<CellLived> cellLivedChannel,
            IConsume<CellDied> cellDiedChannel)
        {
            _cellLivedChannel = cellLivedChannel;
            _cellDiedChannel = cellDiedChannel;
        }

        public void Consume(LivingNeighborsOfDeadCellCounted eventData)
        {
            throw new System.NotImplementedException();
        }
    }
}
