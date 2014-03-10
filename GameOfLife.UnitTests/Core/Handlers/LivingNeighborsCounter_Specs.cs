using GameOfLife.Core.Events;
using GameOfLife.Core.Handlers;
using NSpec;

namespace GameOfLife.UnitTests.Core.Handlers
{
    class CountLivingNeighbors_Specs : nspec
    {
        private CountLivingNeighbors _subject;
        private GenericHandlerForTesting<LivingNeighborsOfLiveCellCounted> _liveCellEventHandler;
        private GenericHandlerForTesting<LivingNeighborsOfDeadCellCounted> _deadCellEventHandler;

        void before_each()
        {
            _liveCellEventHandler = new GenericHandlerForTesting<LivingNeighborsOfLiveCellCounted>();
            _deadCellEventHandler = new GenericHandlerForTesting<LivingNeighborsOfDeadCellCounted>();
            _subject = new CountLivingNeighbors(_liveCellEventHandler, _deadCellEventHandler);
        }

        void it_publishes_an_event_for_each_cell_in_the_grid()
        {
            var eventData = new BuildGenerationComputedEventForGridOfSize(3)
                .WithNLivingCells(5)
                .Build();

            _subject.Consume(eventData);

            _liveCellEventHandler.HandledEvents.Count.should_be(5);
            _deadCellEventHandler.HandledEvents.Count.should_be(4);
        }
    }
}
