using GameOfLife.EventInfrastructure;
using NSpec;

namespace GameOfLife.UnitTests.EventInfrastructure
{
    class DeliverEventsFromChannelUntilEmpty_Specs : nspec
    {
        private DeliverEventsFromChannelUntilEmpty _subject;
        private GenericHandlerForTesting<Event> _handler;
        private Channel _channel;

        void before_each()
        {
            _handler = new GenericHandlerForTesting<Event>();
            _channel = new Channel(_handler);
            _subject = new DeliverEventsFromChannelUntilEmpty(_channel);
        }

        void it_delivers_events_off_the_queue_until_none_are_left()
        {
            _channel.Enqueue(new EventForTesting());
            _channel.Enqueue(new EventForTesting());
            _channel.Enqueue(new EventForTesting());

            _subject.Execute();

            _channel.HasMore().should_be(false);
        }
    }
}
