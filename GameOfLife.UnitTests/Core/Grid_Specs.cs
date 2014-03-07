using System.Collections.Generic;
using System.Linq;
using GameOfLife.Core;
using NSpec;

namespace GameOfLife.UnitTests.Core
{
    class Grid_Specs : nspec
    {
        private Grid<int> _subject;
        private List<int> _sourceList;

        void before_each()
        {
            _sourceList = new List<int>
                {
                    1, 2, 3, 4, 5, 6, 7, 8, 9
                };
            _subject = new Grid<int>(_sourceList);
        }

        void it_has_size_of_the_square_root_of_the_length_of_the_intialization_list()
        {
            _subject.Size.should_be(3);
        }

        void it_can_be_iterated_over()
        {
            _subject.ToList().Count.should_be(9);
        }

        void it_is_able_to_retrieved_cells_by_row_and_column()
        {
            _subject.cellAt(0, 0).should_be(1);
            _subject.cellAt(0, 1).should_be(2);
            _subject.cellAt(0, 2).should_be(3);
            _subject.cellAt(1, 0).should_be(4);
            _subject.cellAt(1, 1).should_be(5);
            _subject.cellAt(1, 2).should_be(6);
            _subject.cellAt(2, 0).should_be(7);
            _subject.cellAt(2, 1).should_be(8);
            _subject.cellAt(2, 2).should_be(9);
        }

        void it_returns_default_for_out_of_bounds_cell_requests()
        {
            _subject.cellAt(-1, -1).should_be(default(int));
            _subject.cellAt(-1, 1).should_be(default(int));
            _subject.cellAt(-1, 3).should_be(default(int));
            _subject.cellAt(1, -1).should_be(default(int));
            _subject.cellAt(1, 3).should_be(default(int));
            _subject.cellAt(3, -1).should_be(default(int));
            _subject.cellAt(3, 1).should_be(default(int));
            _subject.cellAt(3, 3).should_be(default(int));
        }

        void it_is_able_to_retrieved_cells_by_position_in_grid()
        {
            _subject.cellAt(new PositionInGrid
            {
                column = 2,
                row = 1
            }).should_be(6);
            _subject.cellAt(new PositionInGrid
            {
                column = 4,
                row = -1
            }).should_be(default(int));
        }
    }
}
