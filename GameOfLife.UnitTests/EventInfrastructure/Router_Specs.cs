using System;
using GameOfLife.EventInfrastructure;
using NSpec;

namespace GameOfLife.UnitTests.EventInfrastructure
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

        void it_throws_an_error_when_trying_to_invoke_a_handler_that_has_not_been_registered()
        {
            expect<Exception>(() => _subject.InvokeHandler(_event));
        }
    }
}
