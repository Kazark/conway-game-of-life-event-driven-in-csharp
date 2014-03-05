namespace GameOfLife.Events
{
    class CellLived : Event
    {
        public PositionInGrid location { get; set; }
    }
}
