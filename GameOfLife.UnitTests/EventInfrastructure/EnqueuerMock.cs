using System.Collections.Generic;
using System.Linq;
using GameOfLife.EventInfrastructure;

namespace GameOfLife.UnitTests.EventInfrastructure
{
    class EnqueuerMock : IEnqueueEventsOnChannel
    {
        private readonly List<Event> _handledEvents = new List<Event>();

        public int EnqueuedEventsCount
        {
            get { return _handledEvents.Count; }
        }

        public void Enqueue(Event eventData)
        {
            _handledEvents.Add(eventData);
        }

        public bool LastEnqueuedEventWasOfType<T>()
        {
            return EnqueuedAnEvent() && InstanceOf<T>(_handledEvents.Last());
        }

        public bool EnqueuedAnEvent()
        {
            return _handledEvents.Any();
        }

        public bool EnqueuedAnEventOfType<T>()
        {
            return _handledEvents.Any(InstanceOf<T>);
        }

        public int CountEnqueuedEventsOfType<T>()
        {
            return _handledEvents.Count(InstanceOf<T>);
        }

        private static bool InstanceOf<T>(Event eventData)
        {
            return eventData.GetType() == typeof(T);
        }
    }
}
