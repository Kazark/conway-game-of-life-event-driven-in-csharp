using GameOfLife.EventInfrastructure;

namespace GameOfLife.UnitTests
{
    class EventHandlerForTesting : IConsume<Event>
    {
        private readonly EventForTestingHandler _innerHandler;

        public EventHandlerForTesting()
        {
            _innerHandler = new EventForTestingHandler();
        }

        public void Consume(Event eventData)
        {
            _innerHandler.Consume(eventData as EventForTesting);
        }

        public bool ConsumedEventWithId(int id)
        {
            return _innerHandler.ConsumedEventWithId(id);
        }
    }
}
