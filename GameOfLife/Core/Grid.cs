using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Core
{
    public class Grid<T> : IEnumerable<Cell<T>>, IGrid<T>
    {
        private readonly int _size;
        private readonly List<Cell<T>> _data;

        public Grid(List<T> data)
        {
            _size = Convert.ToInt32(Math.Sqrt(data.Count));
            _data = data.Select((v,i) => new Cell<T>(this, PositionInGrid.FromScalarForGridOfSize(i, Size), v)).ToList();
        }

        public int Size
        {
            get { return _size; }
        }

        public IEnumerator<Cell<T>> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Cell<T> CellAt(int row, int column)
        {
            return CellAt(new PositionInGrid
            {
                column = column,
                row = row
            });
        }

        public Cell<T> CellAt(PositionInGrid position)
        {
            if (position.IsOutOfBoundsForGridOfSize(Size))
            {
                return new Cell<T>(this, null, default(T));
            }
            return _data[position.ToScalarForGridOfSize(Size)];
        }
    }
}
