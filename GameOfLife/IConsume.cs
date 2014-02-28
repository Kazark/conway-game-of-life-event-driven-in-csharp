namespace GameOfLife
{
    public interface IConsume<in TEvent> where TEvent : class, Event
    {
        void Consume(TEvent eventData);
    }
}
