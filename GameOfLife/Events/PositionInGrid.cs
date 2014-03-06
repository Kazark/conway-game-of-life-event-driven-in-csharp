namespace GameOfLife.Events
{
    public class PositionInGrid
    {
        public PositionInGrid northernNeighbor()
        {
            return new PositionInGrid { column = column, row = row - 1};
        }
        public PositionInGrid northwesternNeighbor()
        {
            return new PositionInGrid();
        }
        public PositionInGrid westernNeighbor()
        {
            return new PositionInGrid();
        }
        public PositionInGrid southwesternNeighbor()
        {
            return new PositionInGrid();
        }
        public PositionInGrid southernNeighbor()
        {
            return new PositionInGrid();
        }
        public PositionInGrid southeasternNeighbor()
        {
            return new PositionInGrid();
        }
        public PositionInGrid easternNeighbor()
        {
            return new PositionInGrid();
        }
        public PositionInGrid northeasternNeighbor()
        {
            return new PositionInGrid();
        }
        public int row { get; set; }
        public int column { get; set; }
    }
}
