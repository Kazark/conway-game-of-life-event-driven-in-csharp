using GameOfLife.Core.Events;
using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core.Handlers
{
    public class DetermineNextStateOfLivingCell : IConsume<LivingNeighborsOfLiveCellCounted>
    {
        private readonly IConsume<CellLived> _cellLivedChannel;
        private readonly IConsume<CellDied> _cellDiedChannel;

        public DetermineNextStateOfLivingCell(IConsume<CellLived> cellLivedChannel,
            IConsume<CellDied> cellDiedChannel)
        {
            _cellLivedChannel = cellLivedChannel;
            _cellDiedChannel = cellDiedChannel;
        }

        public void Consume(LivingNeighborsOfLiveCellCounted eventData)
        {
            throw new System.NotImplementedException();
        }
    }
}
