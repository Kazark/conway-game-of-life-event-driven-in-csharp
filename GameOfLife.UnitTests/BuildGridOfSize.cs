using System.Collections.Generic;
using GameOfLife.Core;

namespace GameOfLife.UnitTests
{
    class BuildGridOfSize
    {
        private readonly List<bool> _data;

        public BuildGridOfSize(int size)
        {
            var length = size*size;
            _data = new List<bool>(length);
            for (var i = 0; _data.Count < length; i++)
            {
                _data.Add(false);
            }
        }

        public BuildGridOfSize WithNLivingCells(int numberLiving)
        {
            for (int i = 0; i < numberLiving; i++)
            {
                _data[i] = true;
            }
            return this;
        }

        public Grid<bool> Build()
        {
            return new Grid<bool>(_data);
        }
    }
}
