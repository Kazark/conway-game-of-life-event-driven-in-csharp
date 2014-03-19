using GameOfLife.Core.Events;
using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core.Handlers
{
    public class IsGameOscillating : IConsume<StatisNotReached>, IConsume<OneGenerationOfCellStatesAggregated>
    {
        private readonly IEnqueueEventsOnChannel _channel;

        public IsGameOscillating(IEnqueueEventsOnChannel channel)
        {
            _channel = channel;
        }

        public void Consume(StatisNotReached eventData)
        {
        }

        public void Consume(OneGenerationOfCellStatesAggregated eventData)
        {
        }
    }
}
