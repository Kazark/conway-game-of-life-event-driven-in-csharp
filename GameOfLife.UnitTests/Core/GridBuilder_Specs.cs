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
            _subject = new GridBuilder(_channel);
            _subject.SetGridSizeTo(2);
        }

        void it_should_publish_OneGenerationOfCellStatesAggregated_event_once_it_has_all_the_data_to_build_the_grid()
        {
            MarkFourCells();
            _channel.HandledEvents.Count.should_be(1);
            MarkFourCells();
            _channel.HandledEvents.Count.should_be(2);
        }

        void it_should_not_publish_before_it_has_all_the_data_to_build_the_grid()
        {
            MarkThreeCells();
            _channel.HandledEvents.Count.should_be(0);
        }

        void it_should_build_a_grid()
        {
            MarkFourCells();
            var grid = _channel.HandledEvents[0].grid;
            grid.CellAt(0, 0).value.should_be(true);
            grid.CellAt(0, 1).value.should_be(true);
            grid.CellAt(1, 0).value.should_be(false);
            grid.CellAt(1, 1).value.should_be(false);
        }

        void MarkFourCells()
        {
            _subject.MarkCellAliveAt(new PositionInGrid { row = 0, column = 0 });
            _subject.MarkCellDeadAt(new PositionInGrid { row = 1, column = 0 });
            _subject.MarkCellDeadAt(new PositionInGrid { row = 1, column = 1 });
            _subject.MarkCellAliveAt(new PositionInGrid { row = 0, column = 1 });
        }

        void MarkThreeCells()
        {
            _subject.MarkCellDeadAt(new PositionInGrid());
            _subject.MarkCellAliveAt(new PositionInGrid());
            _subject.MarkCellDeadAt(new PositionInGrid());
        }
    }
}
