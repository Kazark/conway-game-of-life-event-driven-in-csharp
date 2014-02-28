namespace GameOfLife.UnitTests
{
    class EventForTestingHandler : IConsume<EventForTesting>
    {
        private EventForTesting _eventData;

        public EventForTestingHandler()
        {
            _eventData = new EventForTesting();
        }

        public void Consume(EventForTesting eventData)
        {
            _eventData = eventData;
        }

        public bool ConsumedEventWithId(int id)
        {
            return _eventData.ID == id;
        }
    }
}
