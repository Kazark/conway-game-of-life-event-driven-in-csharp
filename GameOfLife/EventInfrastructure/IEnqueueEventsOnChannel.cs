namespace GameOfLife.EventInfrastructure
{
    public interface IEnqueueEventsOnChannel
    {
        void Enqueue(Event eventData);
    }
}
