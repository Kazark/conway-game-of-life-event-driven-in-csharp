using System.Collections.Generic;
using System.Linq;
using GameOfLife.Core.Events;
using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core.Handlers
{
    public class HasGameReachedTerminalCondition :
        IConsume<GameInitiated>,
        IConsume<OneGenerationOfCellStatesAggregated>
    {
        private readonly IEnqueueEventsOnChannel _channel;
        private readonly List<List<bool>> _oldStates = new List<List<bool>>();
        private List<bool> _previousState;

        public HasGameReachedTerminalCondition(IEnqueueEventsOnChannel channel)
        {
            _channel = channel;
        }

        public void Consume(GameInitiated eventData)
        {
            _previousState = eventData.grid.AsListOfCellStates();
        }

        public void Consume(OneGenerationOfCellStatesAggregated eventData)
        {
            var newState = eventData.grid.AsListOfCellStates();
            PublishWhetherTerminalStateHasBeenReached(newState);
            _oldStates.Add(_previousState);
            _previousState = newState;
        }

        private void PublishWhetherTerminalStateHasBeenReached(List<bool> newState)
        {
            if (newState.SequenceEqual(_previousState))
            {
                _channel.Enqueue(new GameIsNotOscillating());
                _channel.Enqueue(new StasisReached());
            }
            else
            {
                _channel.Enqueue(new StasisNotReached());
                PublishWhetherKineticGameIsOscillating(newState);
            }
        }

        private void PublishWhetherKineticGameIsOscillating(IEnumerable<bool> newState)
        {
            if (_oldStates.Any(prev => prev.SequenceEqual(newState)))
            {
                _channel.Enqueue(new GameIsOscillating());
            }
            else
            {
                _channel.Enqueue(new GameIsNotOscillating());
            }
        }
    }
}
