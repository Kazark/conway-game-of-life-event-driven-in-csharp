using GameOfLife.Core.Handlers;
using NSpec;

namespace GameOfLife.UnitTests.Core.Handlers
{
    class IsGameOscillating_Specs : nspec
    {
        private IsGameOscillating _subject;

        void before_each()
        {
            _subject = new IsGameOscillating();
        }
    }
}
