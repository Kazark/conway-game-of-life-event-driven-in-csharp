using GameOfLife.Core.Events;
using GameOfLife.Core.Handlers;
using GameOfLife.UnitTests.EventInfrastructure;
using NSpec;

namespace GameOfLife.UnitTests.Core.Handlers
{
    class IsGameOscillating_Specs : nspec
    {
        private const int GridSize = 5;
        private IsGameOscillating _subject;
        private EnqueuerMock _channelMock;

        void before_each()
        {
            _channelMock = new EnqueuerMock();
            _subject = new IsGameOscillating(_channelMock);
            _subject.Consume(new GameInitiated
            {
                grid = new BuildGridOfSize(GridSize).Build()
            });
        }

        void it_publishes_GameIsNotOscillating_if_original_game_is_in_Stasis()
        {
            ConsumeEventOfInitialState();

            _channelMock.EnqueuedEventOfType<GameIsNotOscillating>().should_be_true();
        }

        void it_publishes_StasisReached_event_if_original_game_is_in_stasis()
        {
            ConsumeEventOfInitialState();

            _channelMock.EnqueuedEventOfType<StasisReached>().should_be_true();
        }


        void it_publishes_GameIsNotOscillating_if_game_reaches_Stasis()
        {
            ConsumeEventOfSecondaryState();
            ConsumeEventOfSecondaryState();

            _channelMock.EnqueuedEventOfType<GameIsNotOscillating>().should_be_true();
        }

        void it_publishes_GameIsNotOscillating_after_if_new_generation_does_not_match_old_generations()
        {
            ConsumeEventOfSecondaryState();
            ConsumeEventOfTertiaryState();

            _channelMock.CountEnqueuedEventsOfType<GameIsNotOscillating>().should_be(2);
        }

        void it_publishes_StasisNotReached_if_new_generation_does_not_match_immediately_previous_generation()
        {
            ConsumeEventOfSecondaryState();
            ConsumeEventOfTertiaryState();

            _channelMock.CountEnqueuedEventsOfType<StasisNotReached>().should_be(2);
        }

        void it_publishes_GameIsOscillating_if_game_returns_to_original_state()
        {
            ConsumeEventOfSecondaryState();
            ConsumeEventOfInitialState();

            _channelMock.LastEnqueuedEventWasOfType<GameIsOscillating>().should_be_true();
        }

        private void ConsumeEventOfInitialState()
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

        void ConsumeEventOfTertiaryState()
        {
            _subject.Consume(new OneGenerationOfCellStatesAggregated
            {
                grid = new BuildGridOfSize(GridSize).WithNLivingCells(2).Build()
            });
        }
    }
}
