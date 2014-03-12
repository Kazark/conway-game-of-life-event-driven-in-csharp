using System.Collections.Generic;
using GameOfLife.Core.Events;
using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core
{
    public class GridBuilder
    {
        private readonly IConsume<OneGenerationOfCellStatesAggregated> _channel;
        private readonly List<bool> _cells = new List<bool>();
        private int _count;
        private int _length;
        private int _size;

        public GridBuilder(IConsume<OneGenerationOfCellStatesAggregated> channel)
        {
            _channel = channel;
            _count = 0;
        }

        public void SetGridSizeTo(int size)
        {
            _size = size;
            _length = _size * _size;
            for (var i = 0; i < _length; i++)
            {
                _cells.Add(false);
            }
        }

        public void MarkCellDeadAt(PositionInGrid position)
        {
            _count++;
            _cells[position.ToScalarForGridOfSize(_size)] = false;
            PublishAndResetIfNecessary();
        }

        public void MarkCellAliveAt(PositionInGrid position)
        {
            _count++;
            _cells[position.ToScalarForGridOfSize(_size)] = true;
            PublishAndResetIfNecessary();
        }

        private void PublishAndResetIfNecessary()
        {
            if (_count == _length)
            {
                _count = 0;
                _channel.Consume(new OneGenerationOfCellStatesAggregated
                {
                    grid = new Grid<bool>(_cells)
                });
            }
        }
    }
}
