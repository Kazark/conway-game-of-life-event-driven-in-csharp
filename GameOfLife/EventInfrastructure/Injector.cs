using System;

namespace GameOfLife.EventInfrastructure
{
    public static class BuildInjector
    {
        public class InjectorBuilder<T> where T : class
        {
            public InjectorBuilder<T> Inject<T1>() where T1: class
            {
                throw new System.NotImplementedException();
            }

            public InjectorBuilder<T> Then<T2>() where T2: class
            {
                throw new System.NotImplementedException();
            }

            public Func<LazyInitContainer, T> Build()
            {
                return null;
            }
        }

        public static InjectorBuilder<T> For<T>() where T: class
        {
            return new InjectorBuilder<T>();
        }
    }
}
