using System.Linq;
using GameOfLife.Core;
using NSpec;

namespace GameOfLife.UnitTests.Core
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
            _subject.NorthernNeighbor().row.should_be(1);
            _subject.NorthernNeighbor().column.should_be(0);
        }

        void it_knows_the_position_of_its_northwestern_neighbor()
        {
            _subject.NorthwesternNeighbor().row.should_be(1);
            _subject.NorthwesternNeighbor().column.should_be(-1);
        }

        void it_knows_the_position_of_its_western_neighbor()
        {
            _subject.WesternNeighbor().row.should_be(2);
            _subject.WesternNeighbor().column.should_be(-1);
        }

        void it_knows_the_position_of_its_southwestern_neighbor()
        {
            _subject.SouthwesternNeighbor().row.should_be(3);
            _subject.SouthwesternNeighbor().column.should_be(-1);
        }

        void it_knows_the_position_of_its_southern_neighbor()
        {
            _subject.SouthernNeighbor().row.should_be(3);
            _subject.SouthernNeighbor().column.should_be(0);
        }

        void it_knows_the_position_of_its_southeastern_neighbor()
        {
            _subject.SoutheasternNeighbor().row.should_be(3);
            _subject.SoutheasternNeighbor().column.should_be(1);
        }

        void it_knows_the_position_of_its_eastern_neighbor()
        {
            _subject.EasternNeighbor().row.should_be(2);
            _subject.EasternNeighbor().column.should_be(1);
        }

        void it_knows_the_position_of_its_northeastern_neighbor()
        {
            _subject.NortheasternNeighbor().row.should_be(1);
            _subject.NortheasternNeighbor().column.should_be(1);
        }

        void it_has_an_iterator_for_all_its_neighbors()
        {
            _subject.Neighbors().Count().should_be(8);
        }
    }
}
