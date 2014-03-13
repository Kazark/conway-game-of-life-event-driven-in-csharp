using System.Collections.Generic;

namespace GameOfLife.Core
{
    public class GridBuilder
    {
        private readonly List<bool> _cells = new List<bool>();
        public int length { get; private set; }
        private int _size;

        public GridBuilder SetGridSizeTo(int size)
        {
            _size = size;
            length = _size * _size;
            for (var i = 0; i < length; i++)
            {
                _cells.Add(false);
            }
            return this;
        }

        public void MarkCellDeadAt(PositionInGrid position)
        {
            _cells[position.ToScalarForGridOfSize(_size)] = false;
        }

        public void MarkCellAliveAt(PositionInGrid position)
        {
            _cells[position.ToScalarForGridOfSize(_size)] = true;
        }

        public Grid<bool> Build()
        {
            return new Grid<bool>(_cells);
        }
    }
}
