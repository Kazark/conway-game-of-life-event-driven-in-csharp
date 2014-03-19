using GameOfLife.Core.Events;
using GameOfLife.Core.Handlers;
using GameOfLife.UnitTests.EventInfrastructure;
using NSpec;

namespace GameOfLife.UnitTests.Core.Handlers
{
    class HasGameReachedStatis_Specs : nspec
    {
        private const int GridSize = 5;
        private HasGameReachedStatis _subject;
        private EnqueuerMock _channelMock;

        void before_each()
        {
            _channelMock = new EnqueuerMock();
            _subject = new HasGameReachedStatis(_channelMock);
            _subject.Consume(new GameInitiated
            {
                grid = new BuildGridOfSize(GridSize).Build()
            });
        }

        void ConsumeEventSameAsOriginalState()
        {
            _subject.Consume(new OneGenerationOfCellStatesAggregated
            {
                grid = new BuildGridOfSize(GridSize).Build()
            });
        }

        void ConsumeEventOfSecondaryState()
        {
            _subject.Consume(new OneGenerationOfCellStatesAggregated
            {
                grid = new BuildGridOfSize(GridSize).WithNLivingCells(1).Build()
            });
        }

        void it_publishes_StatisReached_event_when_original_game_is_in_stasis()
        {
            ConsumeEventSameAsOriginalState();
            _channelMock.LastEnqueuedEventWasOfType<StatisReached>().should_be_true();
        }

        void it_does_not_publish_StatisReached_event_when_original_game_has_not_reached_stasis()
        {
            ConsumeEventOfSecondaryState();
            _channelMock.EnqueuedAnEventOfType<StatisReached>().should_be_false();
        }

        void it_publishes_StatisNotReached_event_when_original_game_has_not_reached_stasis()
        {
            ConsumeEventOfSecondaryState();
            _channelMock.LastEnqueuedEventWasOfType<StatisNotReached>().should_be_true();
        }

        void it_does_not_publish_StatisReached_event_when_original_game_is_in_loop()
        {
            ConsumeEventOfSecondaryState();
            ConsumeEventSameAsOriginalState();
            ConsumeEventOfSecondaryState();
            _channelMock.EnqueuedAnEventOfType<StatisReached>().should_be_false();
        }

        void it_publishes_StatisReached_event_when_the_game_has_reached_stasis()
        {
            ConsumeEventOfSecondaryState();
            ConsumeEventOfSecondaryState();
            _channelMock.LastEnqueuedEventWasOfType<StatisReached>().should_be_true();
        }
    }
}
