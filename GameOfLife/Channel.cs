using System.Collections.Generic;

namespace GameOfLife
{
    public class Channel : IConsume<Event>
    {
        private readonly IConsume<Event> _handler;
        private readonly Queue<Event> _eventQueue = new Queue<Event>();

        public Channel(IConsume<Event> handler)
        {
            _handler = handler;
        }

        public bool HasMore()
        {
            return _eventQueue.Count > 0;
        }

        public void Consume(Event eventData)
        {
            _eventQueue.Enqueue(eventData);
        }

        public void DeliverOne()
        {
            _handler.Consume(_eventQueue.Dequeue());
        }
    }
}
