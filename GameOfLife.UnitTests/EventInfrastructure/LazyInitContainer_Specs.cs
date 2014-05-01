using GameOfLife.EventInfrastructure;
using NSpec;

namespace GameOfLife.UnitTests.EventInfrastructure
{
    public class LazyInitContainer_Specs : nspec
    {
        private LazyInitContainer _subject;

        void before_each()
        {
            _subject = new LazyInitContainer();
        }

        void it_returns_null_when_no_injector_is_registered_for_a_type()
        {
            _subject.GetInstanceOf<string>().should_be(null);
        }

        void it_does_not_return_null_when_injector_is_registered_for_a_type()
        {
            const string Instance = "something";
            _subject.RegisterInjector(x => Instance);
            _subject.GetInstanceOf<string>().should_be(Instance);
        }
    }
}
