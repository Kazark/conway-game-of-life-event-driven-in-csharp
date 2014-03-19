using System.Collections.Generic;
using System.Linq;
using GameOfLife.EventInfrastructure;

namespace GameOfLife.UnitTests.EventInfrastructure
{
    class EnqueuerMock : IEnqueueEventsOnChannel
    {
        private readonly List<Event> _handledEvents = new List<Event>();

        public void Enqueue(Event eventData)
        {
            _handledEvents.Add(eventData);
        }

        public bool LastEnqueuedEventWasOfType<T>()
        {
            return _handledEvents.Last().GetType() == typeof(T);
        }

        public bool EnqueuedAnEvent()
        {
            return _handledEvents.Any();
        }

        public bool EnqueuedAnEventOfType<T>()
        {
            return _handledEvents.Any(e => e.GetType() == typeof(T));
        }
    }
}
