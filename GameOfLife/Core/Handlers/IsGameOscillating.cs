using GameOfLife.Core.Events;
using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core.Handlers
{
    public class IsGameOscillating :
        IConsume<GameInitiated>,
        IConsume<OneGenerationOfCellStatesAggregated>,
        IConsume<StatisNotReached>
    {
        private readonly IEnqueueEventsOnChannel _channel;
        private bool _statisNotReached;

        public IsGameOscillating(IEnqueueEventsOnChannel channel)
        {
            _channel = channel;
        }

        public void Consume(StatisNotReached eventData)
        {
            _statisNotReached = true;
        }

        public void Consume(OneGenerationOfCellStatesAggregated eventData)
        {
            if (_statisNotReached)
            {
                _channel.Enqueue(new GameIsNotOscillating());
            }
        }

        public void Consume(GameInitiated eventData)
        {
        }
    }
}
