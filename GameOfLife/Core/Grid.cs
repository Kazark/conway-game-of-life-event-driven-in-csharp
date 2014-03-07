using System;
using System.Collections;
using System.Collections.Generic;

namespace GameOfLife.Core
{
    public class Grid<T> : IEnumerable<T>, IGrid<T>
    {
        private readonly int _size;
        private readonly List<T> _data;

        public Grid(List<T> data)
        {
            _data = data;
            _size = Convert.ToInt32(Math.Sqrt(data.Count));
        }

        public int Size
        {
            get { return _size; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T cellAt(int row, int column)
        {
            if (row < 0 || row >= Size || column < 0 || column >= Size)
            {
                return default(T);
            }
            return _data[row*Size+column];
        }

        public T cellAt(PositionInGrid position)
        {
            return cellAt(position.row, position.column);
        }
    }
}
