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

        void it_does_nothing_if_it_has_only_received_StatisNotReached()
        {
            StatisNotReached();

            _channelMock.EnqueuedAnEvent().should_be_false();
        }

        void it_does_nothing_if_it_has_only_received_OneGenerationOfCellStatesAggregated()
        {
            _subject.Consume(new OneGenerationOfCellStatesAggregated());

            _channelMock.EnqueuedAnEvent().should_be_false();
        }

        void it_publishes_GameIsNotOscillating_after_receiving_both_messages_if_new_generation_does_not_match_previous_generations()
        {
            ConsumeEventOfSecondaryState();
            StatisNotReached();
            ConsumeEventOfTertiaryState();
            StatisNotReached();

            _channelMock.LastEnqueuedEventWasOfType<GameIsNotOscillating>().should_be_true();
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

        void StatisNotReached()
        {
            _subject.Consume(new StatisNotReached());
        }
    }
}
