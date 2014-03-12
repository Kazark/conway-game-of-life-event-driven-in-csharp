using GameOfLife.Core;
using GameOfLife.Core.Events;
using NSpec;

namespace GameOfLife.UnitTests.Core
{
    class GridBuilder_Specs : nspec
    {
        private GridBuilder _subject;
        private GenericHandlerForTesting<OneGenerationOfCellStatesAggregated> _channel;

        void before_each()
        {
            _channel = new GenericHandlerForTesting<OneGenerationOfCellStatesAggregated>();
            _subject = new GridBuilder(_channel)
            {
                Size = 2
            };
        }

        /*void xit_should_publish_OneGenerationOfCellStatesAggregated_event_once_it_has_all_the_data_to_build_the_grid()
        {
            _subject.markCellDeadAt(new PositionInGrid());
            _subject.markCellAliveAt(new PositionInGrid());
            _subject.markCellDeadAt(new PositionInGrid());
        }*/

        void it_should_not_publish_before_it_has_all_the_data_to_build_the_grid()
        {
            _subject.MarkCellDeadAt(new PositionInGrid());
            _subject.MarkCellAliveAt(new PositionInGrid());
            _subject.MarkCellDeadAt(new PositionInGrid());
            _channel.HandledEvents.Count.should_be(0);
        }
    }
}
