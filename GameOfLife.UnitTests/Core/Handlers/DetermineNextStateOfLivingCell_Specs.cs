using GameOfLife.Core;
using GameOfLife.Core.Events;
using GameOfLife.Core.Handlers;
using NSpec;

namespace GameOfLife.UnitTests.Core.Handlers
{
    class DetermineNextStateOfLivingCell_Specs : nspec
    {
        private DetermineNextStateOfLivingCell _subject;
        private GenericHandlerForTesting<CellLived> _cellLivedChannel;
        private GenericHandlerForTesting<CellDied> _cellDiedChannel;

        void before_each()
        {
            _cellLivedChannel = new GenericHandlerForTesting<CellLived>();
            _cellDiedChannel = new GenericHandlerForTesting<CellDied>();
            _subject = new DetermineNextStateOfLivingCell(_cellLivedChannel, _cellDiedChannel);
        }

        void it_determines_that_a_live_cell_with_less_than_two_living_neighbors_dies()
        {
            _subject.Consume(new LivingNeighborsOfLiveCellCounted
            {
                livingNeighbors = 1
            });
            _cellLivedChannel.HandledEvents.Count.should_be(0);
            _cellDiedChannel.HandledEvents.Count.should_be(1);
        }

        void it_determines_that_a_live_cell_with_two_living_neighbors_survives()
        {
            _subject.Consume(new LivingNeighborsOfLiveCellCounted
            {
                livingNeighbors = 2
            });
            _cellLivedChannel.HandledEvents.Count.should_be(1);
            _cellDiedChannel.HandledEvents.Count.should_be(0);
        }

        void it_determines_that_a_live_cell_with_three_living_neighbors_survives()
        {
            _subject.Consume(new LivingNeighborsOfLiveCellCounted
            {
                livingNeighbors = 3
            });
            _cellLivedChannel.HandledEvents.Count.should_be(1);
            _cellDiedChannel.HandledEvents.Count.should_be(0);
        }

        void it_determines_that_a_live_cell_with_more_than_three_living_neighbors_dies()
        {
            _subject.Consume(new LivingNeighborsOfLiveCellCounted
            {
                livingNeighbors = 4
            });
            _cellLivedChannel.HandledEvents.Count.should_be(0);
            _cellDiedChannel.HandledEvents.Count.should_be(1);
        }

        void it_publishes_the_position_of_the_cell_if_it_dies()
        {
            var eventData = new LivingNeighborsOfLiveCellCounted
            {
                position = new PositionInGrid
                {
                    column = 2,
                    row = 3
                }
            };

            _subject.Consume(eventData);

            _cellDiedChannel.HandledEvents[0].position.column.should_be(eventData.position.column);
            _cellDiedChannel.HandledEvents[0].position.row.should_be(eventData.position.row);
        }

        void it_publishes_the_position_of_the_cell_if_it_survives()
        {
            var eventData = new LivingNeighborsOfLiveCellCounted
            {
                livingNeighbors = 3,
                position = new PositionInGrid
                {
                    column = 2,
                    row = 3
                }
            };

            _subject.Consume(eventData);

            _cellLivedChannel.HandledEvents[0].position.column.should_be(eventData.position.column);
            _cellLivedChannel.HandledEvents[0].position.row.should_be(eventData.position.row);
        }
    }
}
