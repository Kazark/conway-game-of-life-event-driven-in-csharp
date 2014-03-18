namespace GameOfLife.EventInfrastructure
{
    public class DeliverEventsFromChannelUntilEmpty
    {
        private readonly IDeliverEventsFromChannel _channel;

        public DeliverEventsFromChannelUntilEmpty(IDeliverEventsFromChannel channel)
        {
            _channel = channel;
        }

        public void Execute()
        {
            while (_channel.HasMore())
            {
                _channel.DeliverOne();
            }
        }
    }
}
