using System.Collections.Generic;
using System.Linq;
using GameOfLife.Core.Events;
using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core.Handlers
{
    public class HasGameReachedStatis :
        IConsume<GameInitiated>,
        IConsume<OneGenerationOfCellStatesAggregated>
    {
        private readonly IEnqueueEventsOnChannel _channel;
        private List<bool> _previousState;

        public HasGameReachedStatis(IEnqueueEventsOnChannel channel)
        {
            _channel = channel;
        }

        public void Consume(OneGenerationOfCellStatesAggregated eventData)
        {
            var currentState = eventData.grid.Select(cell => cell.value).ToList();
            if (currentState.SequenceEqual(_previousState))
            {
                _channel.Enqueue(new StatisReached());
            }
            _previousState = currentState;
        }

        public void Consume(GameInitiated eventData)
        {
            _previousState = eventData.grid.Select(cell => cell.value).ToList();
        }
    }
}
