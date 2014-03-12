using GameOfLife.Core.Events;
using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core
{
    public class GridBuilder
    {
        private readonly IConsume<OneGenerationOfCellStatesAggregated> _channel;
        private int _count;
        private int _size;

        public GridBuilder(IConsume<OneGenerationOfCellStatesAggregated> channel)
        {
            _channel = channel;
            _count = 0;
        }

        public void SetGridSizeTo(int size)
        {
            _size = size*size;
        }

        public void MarkCellDeadAt(PositionInGrid position)
        {
            _count++;
            PublishAndResetIfNecessary();
        }

        public void MarkCellAliveAt(PositionInGrid position)
        {
            _count++;
            PublishAndResetIfNecessary();
        }

        private void PublishAndResetIfNecessary()
        {
            if (_count == _size)
            {
                _channel.Consume(new OneGenerationOfCellStatesAggregated());
            }
        }
    }
}
