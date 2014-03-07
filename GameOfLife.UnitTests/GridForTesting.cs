using GameOfLife.Core;

namespace GameOfLife.UnitTests
{
    class GridForTesting : IGrid<int>
    {
        public Cell<int> CellAt(PositionInGrid position)
        {
            return new Cell<int>(this, position, position.row*position.column);
        }
    }
}
