using System.Collections.Generic;
using System.Linq;
using GameOfLife.Core.Events;
using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core.Handlers
{
    public class IsGameOscillating :
        IConsume<GameInitiated>,
        IConsume<OneGenerationOfCellStatesAggregated>
    {
        private readonly IEnqueueEventsOnChannel _channel;
        private readonly List<List<bool>> _oldStates = new List<List<bool>>();
        private List<bool> _previousState;

        public IsGameOscillating(IEnqueueEventsOnChannel channel)
        {
            _channel = channel;
        }

        public void Consume(OneGenerationOfCellStatesAggregated eventData)
        {
            var newState = eventData.grid.AsListOfCellStates();
            if (newState == _previousState)
            {
                _channel.Enqueue(new GameIsNotOscillating());
            }
            else
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
            _oldStates.Add(_previousState);
            _previousState = newState;
        }

        public void Consume(GameInitiated eventData)
        {
            _previousState = eventData.grid.AsListOfCellStates();
        }
    }
}
