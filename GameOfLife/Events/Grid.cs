using System;
using System.Collections.Generic;

namespace GameOfLife.Events
{
    public class Grid<T>
    {
        private readonly int _size;

        public Grid(List<T> data)
        {
            _size = Convert.ToInt32(Math.Sqrt(data.Count));
        }

        public int Size
        {
            get { return _size; }
        }
    }
}
