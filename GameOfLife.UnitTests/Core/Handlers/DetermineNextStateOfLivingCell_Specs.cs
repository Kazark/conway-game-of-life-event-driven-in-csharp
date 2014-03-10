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

        void it_determines_that_a_dead_cell_with_less_than_three_living_neighbors_stays_dead()
        {
        }

        void it_determines_that_a_dead_cell_with_three_living_neighbors_comes_to_life()
        {
        }

        void it_determines_that_a_dead_cell_with_more_than_three_living_neighbors_stays_dead()
        {
        }

        void it_publishes_position_of_the_cell_if_it_stays_dead()
        {
        }

        void it_publishes_position_of_the_cell_if_it_comes_to_life()
        {
        }
    }
}
