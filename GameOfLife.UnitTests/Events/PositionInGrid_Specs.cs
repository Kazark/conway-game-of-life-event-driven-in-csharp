using GameOfLife.Events;
using NSpec;

namespace GameOfLife.UnitTests.Events
{
    class PositionInGrid_Specs : nspec
    {
        private PositionInGrid _subject;

        void before_each()
        {
            _subject = new PositionInGrid
                {
                    row = 2,
                    column = 0
                };
        }

        void it_knows_the_position_of_its_northern_neighbor()
        {
            _subject.northernNeighbor().row.should_be(1);
            _subject.northernNeighbor().column.should_be(0);
        }
    }
}
