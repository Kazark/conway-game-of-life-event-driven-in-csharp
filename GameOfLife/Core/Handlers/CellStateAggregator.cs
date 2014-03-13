using GameOfLife.Core.Events;
using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core.Handlers
{
    public class CellStateAggregator:
        IConsume<CellDied>,
        IConsume<CellLived>,
        IConsume<GameInitiated>
    {
        private readonly IConsume<OneGenerationOfCellStatesAggregated> _channel;
        private readonly GridBuilder _builder = new GridBuilder();
        private int _count;

        public CellStateAggregator(IConsume<OneGenerationOfCellStatesAggregated> channel)
        {
            _channel = channel;
            _count = 0;
        }

        public void Consume(CellDied eventData)
        {
            _count++;
            _builder.MarkCellDeadAt(eventData.position);
            PublishIfNecessary();
        }

        public void Consume(CellLived eventData)
        {
            _count++;
            _builder.MarkCellAliveAt(eventData.position);
            PublishIfNecessary();
        }

        public void Consume(GameInitiated eventData)
        {
            _builder.SetGridSizeTo(eventData.grid.size);
        }

        private void PublishIfNecessary()
        {
            if (_count == _builder.length)
            {
                _count = 0;
                _channel.Consume(new OneGenerationOfCellStatesAggregated
                {
                    grid = _builder.Build()
                });
            }
        }
    }
}
