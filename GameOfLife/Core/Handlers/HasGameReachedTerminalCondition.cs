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
        private readonly List<Grid<bool>> _oldStates = new List<Grid<bool>>();
        private Grid<bool> _previousState;

        public HasGameReachedTerminalCondition(IEnqueueEventsOnChannel channel)
        {
            _channel = channel;
        }

        public void Consume(GameInitiated eventData)
        {
            _previousState = eventData.grid;
        }

        public void Consume(OneGenerationOfCellStatesAggregated eventData)
        {
            var newState = eventData.grid;
            PublishWhetherTerminalStateHasBeenReached(newState);
            _oldStates.Add(_previousState);
            _previousState = newState;
        }

        private void PublishWhetherTerminalStateHasBeenReached(Grid<bool> newState)
        {
            if (newState.InSameStateAs(_previousState))
            {
                _channel.Enqueue(new StasisReached());
            }
            else
            {
                PublishWhetherKineticGameIsOscillating(newState);
            }
        }

        private void PublishWhetherKineticGameIsOscillating(Grid<bool> newState)
        {
            if (_oldStates.Any(prev => prev.InSameStateAs(newState)))
            {
                _channel.Enqueue(new GameIsOscillating());
            }
            else
            {
                _channel.Enqueue(new GenerationCompleted
                {
                    grid = newState
                });
            }
        }
    }
}
