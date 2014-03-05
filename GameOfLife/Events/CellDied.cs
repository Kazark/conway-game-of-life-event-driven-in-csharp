namespace GameOfLife.Events
{
    class CellDied : Event
    {
        public PositionInGrid location { get; set; }
    }
}
