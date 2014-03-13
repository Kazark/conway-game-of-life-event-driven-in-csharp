namespace GameOfLife.EventInfrastructure
{
    public interface InputChannel
    {
        void Enqueue(Event eventData);
    }
}
