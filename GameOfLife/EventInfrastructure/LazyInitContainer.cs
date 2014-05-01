using System;
using System.Collections.Generic;

namespace GameOfLife.EventInfrastructure
{
    public class LazyInitContainer
    {
        private readonly Dictionary<Type, Func<LazyInitContainer, object>> _injectors = new Dictionary<Type, Func<LazyInitContainer, object>>();

        public T GetInstanceOf<T>() where T : class
        {
            if (_injectors.ContainsKey(typeof(T)))
            {
                return _injectors[typeof(T)](this) as T;
            }
            return null;
        }

        public void RegisterInjector<T>(Func<LazyInitContainer, T> injector) where T: class
        {
            _injectors.Add(typeof(T), injector);
        }
    }
}
