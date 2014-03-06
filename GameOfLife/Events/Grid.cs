using System;
using System.Collections;
using System.Collections.Generic;

namespace GameOfLife.Events
{
    public class Grid<T> : IEnumerable<T>
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
    }
}
