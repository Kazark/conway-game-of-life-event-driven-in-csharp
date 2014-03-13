using GameOfLife.Core;
using GameOfLife.Core.Events;
using GameOfLife.Core.Handlers;
using NSpec;

namespace GameOfLife.UnitTests.Core.Handlers
{
    class CellStateAggregator_Specs : nspec
    {
        private CellStateAggregator _subject;
        private GenericHandlerForTesting<OneGenerationOfCellStatesAggregated> _channel;

        void before_each()
        {
            _channel = new GenericHandlerForTesting<OneGenerationOfCellStatesAggregated>();
            _subject = new CellStateAggregator(_channel);
            _subject.Consume(new GameInitiated
            {
                grid = new GridBuilder().SetGridSizeTo(2).Build()
            });
        }

        void it_should_aggregate_cell_state_data_from_CellLived_and_CellDied_messages()
        {
            PublishFourCellStateEvents();
            _channel.HandledEvents.Count.should_be(1);
            PublishFourCellStateEvents();
            _channel.HandledEvents.Count.should_be(2);
        }

        void it_should_publish_an_OneGenerationOfCellStatesAggregated_event_with_a_grid()
        {
            PublishFourCellStateEvents();
            var grid = _channel.HandledEvents[0].grid;
            grid.CellAt(0, 0).value.should_be(true);
            grid.CellAt(0, 1).value.should_be(true);
            grid.CellAt(1, 0).value.should_be(false);
            grid.CellAt(1, 1).value.should_be(false);
        }

        void it_should_not_publish_before_it_has_all_the_data_to_build_the_grid()
        {
            PublishThreeCellStateEvents();
            _channel.HandledEvents.Count.should_be(0);
        }

        void PublishFourCellStateEvents()
        {
            _subject.Consume(new CellLived(0, 0));
            _subject.Consume(new CellDied(1, 0));
            _subject.Consume(new CellDied(1, 1));
            _subject.Consume(new CellLived(0, 1));
        }

        void PublishThreeCellStateEvents()
        {
            _subject.Consume(new CellDied());
            _subject.Consume(new CellLived());
            _subject.Consume(new CellDied());
        }
    }
}
