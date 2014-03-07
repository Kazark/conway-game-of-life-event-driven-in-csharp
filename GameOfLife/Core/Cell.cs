using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Core
{
    public class Cell<T>
    {
        private readonly IGrid<T> _grid;

        public T value { get; private set; }
        public PositionInGrid position { get; private set; }

        public Cell(IGrid<T> grid, PositionInGrid position, T value)
        {
            _grid = grid;
            this.position = position;
            this.value = value;
        }

        public IEnumerable<Cell<T>> Neighbors()
        {
            return position.Neighbors().Select(pos => _grid.CellAt(pos));
        }
    }
}
