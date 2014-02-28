using NSpec;

namespace GameOfLife.UnitTests
{
    class Router_Specs : nspec
    {
        void bootstrap_the_project_for_testing()
        {
            it["hello world"] =
              () => "hello world".should_be("hello world");
        }
    }
}
