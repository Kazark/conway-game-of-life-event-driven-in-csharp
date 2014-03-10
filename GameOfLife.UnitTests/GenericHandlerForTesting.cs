using System.Collections.Generic;
using GameOfLife.EventInfrastructure;

namespace GameOfLife.UnitTests
{
    class GenericHandlerForTesting<TEvent> : IConsume<TEvent> where TEvent : class, Event
    {
        public GenericHandlerForTesting()
        {
            HandledEvents = new List<TEvent>();
        }

        public void Consume(TEvent eventData)
        {
            HandledEvents.Add(eventData);
        }

        public List<TEvent> HandledEvents { get; private set; }
    }
}
