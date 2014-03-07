using System.Linq;
using GameOfLife.Core;
using NSpec;

namespace GameOfLife.UnitTests.Core
{
    class Cell_Specs : nspec
    {
        private Cell<int> _subject;
        private static readonly PositionInGrid Position = new PositionInGrid
            {
                column = 1,
                row = 3
            };
        private const int Value = 2;

        void before_each()
        {
            _subject = new Cell<int>(new GridForTesting(), Position, Value);
        }

        void it_has_position_and_value_properties()
        {
            _subject.position.column.should_be(Position.column);
            _subject.position.row.should_be(Position.row);
            _subject.value.should_be(Value);
        }

        void it_has_a_neighbors_iterator()
        {
            _subject.Neighbors().Count().should_be(8);
        }
    }
}
