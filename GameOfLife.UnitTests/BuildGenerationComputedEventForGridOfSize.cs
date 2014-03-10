using System.Collections.Generic;
using GameOfLife.Core;
using GameOfLife.Core.Events;

namespace GameOfLife.UnitTests
{
    class BuildGenerationComputedEventForGridOfSize
    {
        private readonly List<bool> _data;

        public BuildGenerationComputedEventForGridOfSize(int size)
        {
            var length = size*size;
            _data = new List<bool>(length);
            for (var i = 0; _data.Count < length; i++)
            {
                _data.Add(false);
            }
        }

        public BuildGenerationComputedEventForGridOfSize WithNLivingCells(int numberLiving)
        {
            for (int i = 0; i < numberLiving; i++)
            {
                _data[i] = true;
            }
            return this;
        }

        public GenerationComputed Build()
        {
            return new GenerationComputed
            {
                grid = new Grid<bool>(_data)
            };
        }
    }
}
