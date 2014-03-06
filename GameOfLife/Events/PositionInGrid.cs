namespace GameOfLife.Events
{
    public class PositionInGrid
    {
        public PositionInGrid northernNeighbor()
        {
            return new PositionInGrid { column = column, row = row - 1 };
        }
        public PositionInGrid northwesternNeighbor()
        {
            return new PositionInGrid { column = column - 1, row = row - 1 };
        }
        public PositionInGrid westernNeighbor()
        {
            return new PositionInGrid { column = column - 1, row = row };
        }
        public PositionInGrid southwesternNeighbor()
        {
            return new PositionInGrid { column = column - 1, row = row + 1 };
        }
        public PositionInGrid southernNeighbor()
        {
            return new PositionInGrid { column = column, row = row + 1 };
        }
        public PositionInGrid southeasternNeighbor()
        {
            return new PositionInGrid { column = column + 1, row = row + 1 };
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
