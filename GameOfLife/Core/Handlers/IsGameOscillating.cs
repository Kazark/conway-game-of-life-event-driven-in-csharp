using GameOfLife.Core.Events;
using GameOfLife.EventInfrastructure;

namespace GameOfLife.Core.Handlers
{
    public class IsGameOscillating :
        IConsume<GameInitiated>,
        IConsume<OneGenerationOfCellStatesAggregated>
    {
        private readonly IEnqueueEventsOnChannel _channel;

        public IsGameOscillating(IEnqueueEventsOnChannel channel)
        {
            _channel = channel;
        }

        public void Consume(OneGenerationOfCellStatesAggregated eventData)
        {
            _channel.Enqueue(new GameIsNotOscillating());
        }

        public void Consume(GameInitiated eventData)
        {
        }
    }
}
