namespace GameOfLife.EventInfrastructure
{
    public interface IConsume<in TEvent> where TEvent : class, Event
    {
        void Consume(TEvent eventData);
    }
}
