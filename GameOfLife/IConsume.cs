namespace GameOfLife
{
    interface IConsume<in TEvent>
    {
        void Consume(TEvent eventData);
    }
}
