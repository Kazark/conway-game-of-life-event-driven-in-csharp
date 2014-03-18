namespace GameOfLife.EventInfrastructure
{
    public interface IDeliverEventsFromChannel
    {
        bool HasMore();
        void DeliverOne();
    }
}
