﻿using GameOfLife.Core.Events;
using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core.Handlers
{
    class DetermineNextStateOfLivingCell : IConsume<LivingNeighborsOfLiveCellCounted>
    {
        public void Consume(LivingNeighborsOfLiveCellCounted eventData)
        {
            throw new System.NotImplementedException();
        }
    }
}