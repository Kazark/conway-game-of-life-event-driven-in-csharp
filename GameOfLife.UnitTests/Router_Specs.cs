using NSpec;

namespace GameOfLife.UnitTests
{
    class Router_Specs : nspec
    {
        private Router _subject;
        private EventForTestingHandler _handler;
        private EventForTesting _event;

        void before_each()
        {
            _subject = new Router();
            _handler = new EventForTestingHandler();
            _event = new EventForTesting
                {
                    ID = 6
                };
        }

        void it_can_register_and_invoke_handlers()
        {
            _subject.RegisterHandler(_handler);
            _subject.InvokeHandler(_event);

            _handler.ConsumedEventWithId(_event.ID).should_be_true();
        }
    }
}
