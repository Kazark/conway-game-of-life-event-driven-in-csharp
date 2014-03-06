using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Events
{
    public class Grid<T> : IEnumerable<IGridCell<T>>
    {
        private readonly int _size;
        private readonly List<Cell> _data;

        public Grid(List<T> data)
        {
            _data = data.Select((v,p) => new Cell
                {
                    position = p,
                    value = v,
                    grid = this
                }).ToList();
            _size = Convert.ToInt32(Math.Sqrt(data.Count));
        }

        public int Size
        {
            get { return _size; }
        }

        public IEnumerator<IGridCell<T>> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        class Cell : IGridCell<T>
        {
            public int position { get; set; }
            public T value { get; set; }
            public IEnumerable<T> neighbors
            {
                get
                {
                    return new List<T>
                        {
                            grid.valueAt(position - 1),
                            grid.valueAt(position - grid._size - 1),
                            grid.valueAt(position - grid._size),
                            grid.valueAt(position - grid._size + 1),
                            grid.valueAt(position + 1),
                            grid.valueAt(position + grid._size + 1),
                            grid.valueAt(position + grid._size),
                            grid.valueAt(position + grid._size - 1),
                        };
                }
            }

            public Grid<T> grid { get; set; }
        }

        private T valueAt(int i)
        {
            if (i < 0 || i > _data.Count)
            {
                return default(T);
            }
            return _data[i].value;
        }
    }

    public interface IGridCell<T>
    {
        IEnumerable<T> neighbors { get; }
        T value { get; }
    }
}
