﻿using System.Linq;
using GameOfLife.Core.Events;
using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core.Handlers
{
    public class LivingNeighborsCounter : IConsume<GenerationComputed>
    {
        private readonly IConsume<LivingNeighborsOfLiveCellCounted> _liveCellEventHandler;
        private readonly IConsume<LivingNeighborsOfDeadCellCounted> _deadCellEventHandler;

        public LivingNeighborsCounter(IConsume<LivingNeighborsOfLiveCellCounted> liveCellEventHandler,
            IConsume<LivingNeighborsOfDeadCellCounted> deadCellEventHandler)
        {
            _liveCellEventHandler = liveCellEventHandler;
            _deadCellEventHandler = deadCellEventHandler;
        }

        public void Consume(GenerationComputed eventData)
        {
            foreach (var cell in eventData.grid)
            {
                var numberLiving = cell.Neighbors().Count(n => n.value);
                if (cell.value)
                {
                    _liveCellEventHandler.Consume(new LivingNeighborsOfLiveCellCounted
                    {
                        livingNeighbors = numberLiving,
                        position = cell.position
                    });
                }
                else
                {
                    _deadCellEventHandler.Consume(new LivingNeighborsOfDeadCellCounted
                    {
                        livingNeighbors = numberLiving,
                        position = cell.position
                    });
                }
            }
        }
    }
}
