﻿using GameOfLife.Core.Events;
using GameOfLife.Core.Handlers;
using GameOfLife.UnitTests.EventInfrastructure;
using NSpec;

namespace GameOfLife.UnitTests.Core.Handlers
{
    class HasGameReachedStatis_Specs : nspec
    {
        private const int GridSize = 5;
        private HasGameReachedStatis _subject;
        private EnqueuerMock _channelMock;

        void before_each()
        {
            _channelMock = new EnqueuerMock();
            _subject = new HasGameReachedStatis(_channelMock);
            _subject.Consume(new GameInitiated
            {
                grid = new BuildGridOfSize(GridSize).Build()
            });
        }

        void it_publishes_StatisReached_event_when_original_game_is_in_equilibrium()
        {
            _subject.Consume(new OneGenerationOfCellStatesAggregated
            {
                grid = new BuildGridOfSize(GridSize).Build()
            });

            _channelMock.LastEnqueuedEventWasOfType<StatisReached>().should_be_true();
        }

        void it_does_not_publish_StatisReached_event_when_original_game_has_not_reached_equilibrium()
        {
            _subject.Consume(new OneGenerationOfCellStatesAggregated
            {
                grid = new BuildGridOfSize(GridSize).WithNLivingCells(1).Build()
            });

            _channelMock.EnqueuedAnEvent().should_be_false();
        }

        void it_publishes_StatisReached_event_when_the_game_has_reached_equilibrium()
        {
            _subject.Consume(new OneGenerationOfCellStatesAggregated
            {
                grid = new BuildGridOfSize(GridSize).WithNLivingCells(1).Build()
            });
            _subject.Consume(new OneGenerationOfCellStatesAggregated
            {
                grid = new BuildGridOfSize(GridSize).WithNLivingCells(1).Build()
            });

            _channelMock.LastEnqueuedEventWasOfType<StatisReached>().should_be_true();
        }
    }
}
