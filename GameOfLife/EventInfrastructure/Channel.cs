using System.Collections.Generic;

namespace GameOfLife.EventInfrastructure
{
    public class Channel : IEnqueueEventsOnChannel, IDeliverEventsFromChannel
    {
        private readonly IConsume<Event> _handler;
        private readonly Queue<Event> _eventQueue = new Queue<Event>();

        public Channel(IConsume<Event> handler)
        {
            _handler = handler;
        }

        public void Enqueue(Event eventData)
        {
            _eventQueue.Enqueue(eventData);
        }

        public bool HasMore()
        {
            return _eventQueue.Count > 0;
        }

        public void DeliverOne()
        {
            _handler.Consume(_eventQueue.Dequeue());
        }
    }
}
