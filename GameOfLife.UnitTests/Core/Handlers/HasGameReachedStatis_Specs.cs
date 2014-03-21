using GameOfLife.Core.Events;
using GameOfLife.Core.Handlers;
using GameOfLife.UnitTests.EventInfrastructure;
using NSpec;

namespace GameOfLife.UnitTests.Core.Handlers
{
    class HasGameReachedStasis_Specs : nspec
    {
        private const int GridSize = 5;
        private HasGameReachedStasis _subject;
        private EnqueuerMock _channelMock;

        void before_each()
        {
            _channelMock = new EnqueuerMock();
            _subject = new HasGameReachedStasis(_channelMock);
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

        void it_publishes_StasisReached_event_when_original_game_is_in_stasis()
        {
            ConsumeEventSameAsOriginalState();
            _channelMock.LastEnqueuedEventWasOfType<StasisReached>().should_be_true();
        }

        void it_does_not_publish_StasisReached_event_when_original_game_has_not_reached_stasis()
        {
            ConsumeEventOfSecondaryState();
            _channelMock.EnqueuedEventOfType<StasisReached>().should_be_false();
        }

        void it_publishes_StasisNotReached_event_when_original_game_has_not_reached_stasis()
        {
            ConsumeEventOfSecondaryState();
            _channelMock.LastEnqueuedEventWasOfType<StasisNotReached>().should_be_true();
        }

        void it_does_not_publish_StasisReached_event_when_original_game_is_in_loop()
        {
            ConsumeEventOfSecondaryState();
            ConsumeEventSameAsOriginalState();
            ConsumeEventOfSecondaryState();
            _channelMock.EnqueuedEventOfType<StasisReached>().should_be_false();
        }

        void it_publishes_StasisReached_event_when_the_game_has_reached_stasis()
        {
            ConsumeEventOfSecondaryState();
            ConsumeEventOfSecondaryState();
            _channelMock.LastEnqueuedEventWasOfType<StasisReached>().should_be_true();
        }
    }
}
