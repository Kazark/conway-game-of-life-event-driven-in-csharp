using GameOfLife.Core.Handlers;
using NSpec;

namespace GameOfLife.UnitTests.Core.Handlers
{
    class HasGameReachedStatis_Specs : nspec
    {
        private HasGameReachedStatis _subject;

        void before_each()
        {
            _subject = new HasGameReachedStatis();
        }
    }
}
