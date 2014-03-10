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
            _data = new List<bool>(size*size);
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
