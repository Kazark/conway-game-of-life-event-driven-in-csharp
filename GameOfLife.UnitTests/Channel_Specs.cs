using NSpec;

namespace GameOfLife.UnitTests
{
    class Channel_Specs : nspec
    {
        private Channel _subject;
        private EventHandlerForTesting _handler;
        private EventForTesting _event;

        void before_each()
        {
            _handler = new EventHandlerForTesting();
            _subject = new Channel(_handler);
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
            _subject.Consume(_event);
            _subject.HasMore().should_be_true();
        }

        void it_can_pull_events_off_the_queue()
        {
            _subject.Consume(_event);
            _subject.DeliverOne();
            _subject.HasMore().should_be_false();
        }

        void it_pulls_events_off_one_at_a_time()
        {
            _subject.Consume(_event);
            _subject.Consume(new EventForTesting());
            _subject.DeliverOne();
            _subject.HasMore().should_be_true();
        }

        void it_has_a_FIFO_queueing_discipline()
        {
            _subject.Consume(_event);
            _subject.Consume(new EventForTesting());
            _subject.DeliverOne();
            _handler.ConsumedEventWithId(_event.ID).should_be_true();
        }

        void it_passes_the_event_to_the_handler_when_dequeueing_it()
        {
            _subject.Consume(_event);
            _subject.DeliverOne();
            _handler.ConsumedEventWithId(_event.ID).should_be_true();
        }
    }
}
