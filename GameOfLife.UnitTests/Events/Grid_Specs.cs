using System.Collections.Generic;
using System.Linq;
using NSpec;
using GameOfLife.Events;

namespace GameOfLife.UnitTests.Events
{
    class Grid_Specs : nspec
    {
        private Grid<int> _subject;
        private List<int> _sourceList;

        void before_each()
        {
            _sourceList = new List<int>
                {
                    0, 1, 2, 3, 4, 5, 6, 7, 8, 9
                };
            _subject = new Grid<int>(_sourceList);
        }

        void it_has_size_of_the_square_root_of_the_length_of_the_intialization_list()
        {
            _subject.Size.should_be(3);
        }

        void it_can_be_iterated_over()
        {
            _subject.ToList().should_be(_sourceList);
        }
    }
}
