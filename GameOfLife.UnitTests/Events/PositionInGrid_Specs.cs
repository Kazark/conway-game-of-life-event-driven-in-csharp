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

        void it_knows_the_position_of_its_northwestern_neighbor()
        {
            _subject.northwesternNeighbor().row.should_be(1);
            _subject.northwesternNeighbor().column.should_be(-1);
        }

        void it_knows_the_position_of_its_western_neighbor()
        {
            _subject.westernNeighbor().row.should_be(2);
            _subject.westernNeighbor().column.should_be(-1);
        }

        void it_knows_the_position_of_its_southwestern_neighbor()
        {
            _subject.southwesternNeighbor().row.should_be(3);
            _subject.southwesternNeighbor().column.should_be(-1);
        }
    }
}
