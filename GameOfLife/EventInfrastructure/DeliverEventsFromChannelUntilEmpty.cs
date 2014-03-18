namespace GameOfLife.EventInfrastructure
{
    public class DeliverEventsFromChannelUntilEmpty
    {
        private readonly OutputChannel _channel;

        public DeliverEventsFromChannelUntilEmpty(OutputChannel channel)
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
