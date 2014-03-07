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
            _data = data.Select((v,i) => new Cell<T>(this, new PositionInGrid { column = i % Size, row = i / Size}, v)).ToList();
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

        public T CellValueAt(int row, int column)
        {
            if (row < 0 || row >= Size || column < 0 || column >= Size)
            {
                return default(T);
            }
            return _data[row*Size+column].value;
        }

        public Cell<T> CellAt(PositionInGrid position)
        {
            return new Cell<T>(this, position, CellValueAt(position.row, position.column));
        }
    }
}
