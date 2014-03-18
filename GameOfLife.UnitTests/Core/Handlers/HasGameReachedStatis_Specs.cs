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

        void it_publishes_StatisReached_event_when_original_game_is_in_statis()
        {
            _subject.Consume(new OneGenerationOfCellStatesAggregated
            {
                grid = new BuildGridOfSize(GridSize).Build()
            });

            _channelMock.LastHandledEventWasOfType<StatisReached>().should_be(true);
        }
    }
}
