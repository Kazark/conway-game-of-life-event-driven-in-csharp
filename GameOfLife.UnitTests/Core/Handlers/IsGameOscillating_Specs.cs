using GameOfLife.Core.Events;
using GameOfLife.Core.Handlers;
using GameOfLife.UnitTests.EventInfrastructure;
using NSpec;

namespace GameOfLife.UnitTests.Core.Handlers
{
    class IsGameOscillating_Specs : nspec
    {
        private IsGameOscillating _subject;
        private EnqueuerMock _channelMock;

        void before_each()
        {
            _channelMock = new EnqueuerMock();
            _subject = new IsGameOscillating(_channelMock);
        }

        void it_does_nothing_if_it_has_only_received_StatisNotReached()
        {
            _subject.Consume(new StatisNotReached());

            _channelMock.EnqueuedAnEvent().should_be_false();
        }

        void it_does_nothing_if_it_has_only_received_OneGenerationOfCellStatesAggregated()
        {
            _subject.Consume(new OneGenerationOfCellStatesAggregated());

            _channelMock.EnqueuedAnEvent().should_be_false();
        }
    }
}
