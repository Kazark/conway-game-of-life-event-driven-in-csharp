using GameOfLife.Core.Events;
using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core
{
    public class GridBuilder
    {
        private readonly IConsume<OneGenerationOfCellStatesAggregated> _channel;

        public int Size { private get; set; }

        public GridBuilder(IConsume<OneGenerationOfCellStatesAggregated> channel)
        {
            _channel = channel;
        }

        public void MarkCellDeadAt(PositionInGrid p0)
        {
        }

        public void MarkCellAliveAt(PositionInGrid positionInGrid)
        {
        }
    }
}
