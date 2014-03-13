namespace GameOfLife.EventInfrastructure
{
    public interface IChannel
    {
        void Enqueue(Event eventData);
    }
}
