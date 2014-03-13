namespace GameOfLife.EventInfrastructure
{
    public interface OutputChannel
    {
        bool HasMore();
        void DeliverOne();
    }
}
