using System;
using System.Collections.Generic;

namespace GameOfLife.EventInfrastructure
{
    public class LazyInitContainer
    {
        private readonly Dictionary<Type, Func<LazyInitContainer, object>> _injectors = new Dictionary<Type, Func<LazyInitContainer, object>>();
        private readonly Dictionary<Type, object> _repository = new Dictionary<Type, object>();

        public T GetInstanceOf<T>() where T : class
        {
            if (_repository.ContainsKey(typeof(T)))
            {
                return _repository[typeof(T)] as T;
            }

            if (_injectors.ContainsKey(typeof(T)))
            {
                var instance = _injectors[typeof(T)](this) as T;
                _repository[typeof(T)] = instance;
                return instance;
            }
            return null;
        }

        public void RegisterInjector<T>(Func<LazyInitContainer, T> injector) where T: class
        {
            _injectors.Add(typeof(T), injector);
        }
    }
}
