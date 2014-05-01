using System;
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

        void it_scopes_instances_as_singletons()
        {
            _subject.RegisterInjector(x => Guid.NewGuid().ToString());
            var instance1 = _subject.GetInstanceOf<string>();
            var instance2 = _subject.GetInstanceOf<string>();
            instance1.should_be(instance2);
        }
    }
}
