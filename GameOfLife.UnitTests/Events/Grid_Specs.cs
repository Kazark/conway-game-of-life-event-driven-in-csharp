using NSpec;
using GameOfLife.Events;

namespace GameOfLife.UnitTests.Events
{
    class Grid_Specs : nspec
    {
        private Grid _subject;

        public void it_is_initialized_with_number_of_rows_which_is_also_the_number_of_columns()
        {
            _subject = new Grid(4);

            _subject.Size.should_be(4);
        }
    }
}
