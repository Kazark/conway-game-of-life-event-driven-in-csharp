﻿using System;
using System.Collections.Generic;

namespace GameOfLife.EventInfrastructure
{
    public class Router : IConsume<Event>
    {
        private readonly Dictionary<Type, Action<Event>> _registry;

        public Router()
        {
            _registry = new Dictionary<Type, Action<Event>>();
        }

        public void RegisterHandler<T>(IConsume<T> handler) where T : class, Event
        {
            _registry.Add(typeof(T), e => handler.Consume(e as T));
        }

        public void InvokeHandler(Event eventData)
        {
            _registry[eventData.GetType()](eventData);
        }

        public void Consume(Event eventData)
        {
            InvokeHandler(eventData);
        }

        public void RegisterHandlerForType(object instance, Type genericParameterType)
        {
            GetType().GetMethod("RegisterHandler").Invoke(instance);
        }
    }
}
