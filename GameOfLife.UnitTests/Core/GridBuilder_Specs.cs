using GameOfLife.Core;
using NSpec;

namespace GameOfLife.UnitTests.Core
{
    class GridBuilder_Specs : nspec
    {
        private GridBuilder _subject;

        void before_each()
        {
            _subject = new GridBuilder();
            _subject.SetGridSizeTo(2);
        }

        void it_should_create_grid_of_assigned_size()
        {
            _subject.Build().size.should_be(2);
        }

        void it_should_build_a_grid()
        {
            _subject.MarkCellAliveAt(new PositionInGrid { row = 0, column = 0 });
            _subject.MarkCellDeadAt(new PositionInGrid { row = 1, column = 0 });
            _subject.MarkCellDeadAt(new PositionInGrid { row = 1, column = 1 });
            _subject.MarkCellAliveAt(new PositionInGrid { row = 0, column = 1 });
            var grid = _subject.Build();
            grid.CellAt(0, 0).value.should_be(true);
            grid.CellAt(0, 1).value.should_be(true);
            grid.CellAt(1, 0).value.should_be(false);
            grid.CellAt(1, 1).value.should_be(false);
        }
    }
}
