using GameOfLife.Core.Handlers;
using NSpec;

namespace GameOfLife.UnitTests.Core.Handlers
{
    class DetermineNextStateOfDeadCell_Specs : nspec
    {
        private DetermineNextStateOfDeadCell _subject;

        void before_each()
        {
        }

        void it_determines_that_a_live_cell_with_less_than_two_living_neighbors_dies()
        {
        }

        void it_determines_that_a_live_cell_with_two_living_neighbors_survives()
        {
        }

        void it_determines_that_a_live_cell_with_three_living_neighbors_survives()
        {
        }

        void it_determines_that_a_live_cell_with_more_than_three_living_neighbors_dies()
        {
        }

        void it_publishes_the_position_of_the_cell_if_it_dies()
        {
        }

        void it_publishes_the_position_of_the_cell_if_it_survives()
        {
        }
    }
}
