using GameOfLife.Core;
using GameOfLife.Core.Events;
using GameOfLife.Core.Handlers;
using NSpec;

namespace GameOfLife.UnitTests.Core.Handlers
{
    class DetermineNextStateOfDeadCell_Specs : nspec
    {
        private DetermineNextStateOfDeadCell _subject;
        private GenericHandlerForTesting<CellLived> _cellLivedChannel;
        private GenericHandlerForTesting<CellDied> _cellDiedChannel;

        void before_each()
        {
            _cellLivedChannel = new GenericHandlerForTesting<CellLived>();
            _cellDiedChannel = new GenericHandlerForTesting<CellDied>();
            _subject = new DetermineNextStateOfDeadCell(_cellLivedChannel, _cellDiedChannel);
        }

        void it_determines_that_a_dead_cell_with_less_than_three_living_neighbors_stays_dead()
        {
            _subject.Consume(new LivingNeighborsOfDeadCellCounted
            {
                livingNeighbors = 2
            });
            _cellLivedChannel.HandledEvents.Count.should_be(0);
            _cellDiedChannel.HandledEvents.Count.should_be(1);
        }

        void it_determines_that_a_dead_cell_with_three_living_neighbors_comes_to_life()
        {
            _subject.Consume(new LivingNeighborsOfDeadCellCounted
            {
                livingNeighbors = 3
            });
            _cellLivedChannel.HandledEvents.Count.should_be(1);
            _cellDiedChannel.HandledEvents.Count.should_be(0);
        }

        void it_determines_that_a_dead_cell_with_more_than_three_living_neighbors_stays_dead()
        {
            _subject.Consume(new LivingNeighborsOfDeadCellCounted
            {
                livingNeighbors = 4
            });
            _cellLivedChannel.HandledEvents.Count.should_be(0);
            _cellDiedChannel.HandledEvents.Count.should_be(1);
        }

        void it_publishes_position_of_the_cell_if_it_stays_dead()
        {
            var eventData = new LivingNeighborsOfDeadCellCounted
            {
                position = new PositionInGrid(3, 2)
            };

            _subject.Consume(eventData);

            _cellDiedChannel.HandledEvents[0].position.column.should_be(eventData.position.column);
            _cellDiedChannel.HandledEvents[0].position.row.should_be(eventData.position.row);
        }

        void it_publishes_position_of_the_cell_if_it_comes_to_life()
        {
            var eventData = new LivingNeighborsOfDeadCellCounted
            {
                livingNeighbors = 3,
                position = new PositionInGrid(3, 2)
            };

            _subject.Consume(eventData);

            _cellLivedChannel.HandledEvents[0].position.column.should_be(eventData.position.column);
            _cellLivedChannel.HandledEvents[0].position.row.should_be(eventData.position.row);
        }
    }
}
