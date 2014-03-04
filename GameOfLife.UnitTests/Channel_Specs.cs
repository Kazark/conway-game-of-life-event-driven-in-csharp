using NSpec;

namespace GameOfLife.UnitTests
{
    class Channel_Specs : nspec
    {
        private Channel _subject;
        private EventForTestingHandler _handler;
        private EventForTesting _event;

        void before_each()
        {
            _subject = new Channel();
            _handler = new EventForTestingHandler();
            _event = new EventForTesting
                {
                    ID = 6
                };
        }

        void it_is_empty_at_initialization()
        {
            _subject.HasMore().should_be_false();
        }

        void it_can_add_events_to_the_queue()
        {
            _subject.Consume(new EventForTesting());
            _subject.HasMore().should_be_true();
        }
    }
}
