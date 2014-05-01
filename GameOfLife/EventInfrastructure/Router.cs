using System;
using System.Collections.Generic;

namespace GameOfLife.EventInfrastructure
{
    public class Router
    {
        private delegate void Publish(Event eventData);
        private readonly Dictionary<Type, Publish> _registry;

        public Router()
        {
            _registry = new Dictionary<Type, Publish>();
        }

        public void RegisterHandler<T>(IConsume<T> handler) where T : class, Event
        {
            if (_registry.ContainsKey(typeof(T)))
            {
                _registry[typeof(T)] += e => handler.Consume(e as T);
            }
            else
            {
                _registry.Add(typeof(T), e => handler.Consume(e as T));
            }
        }

        public void InvokeHandler(Event eventData)
        {
            _registry[eventData.GetType()](eventData);
        }
    }
}
