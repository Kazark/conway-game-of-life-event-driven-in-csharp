using GameOfLife.EventInfrastructure;
using NSpec;

namespace GameOfLife.UnitTests.EventInfrastructure
{
    class DeliverEventsFromChannelUntilEmpty_Specs : nspec
    {
        private DeliverEventsFromChannelUntilEmpty _subject;
        private GenericHandlerForTesting<Event> _handler;

        void before_each()
        {
            _handler = new GenericHandlerForTesting<Event>();
            _subject = new DeliverEventsFromChannelUntilEmpty(new Channel(_handler));
        }
    }
}
