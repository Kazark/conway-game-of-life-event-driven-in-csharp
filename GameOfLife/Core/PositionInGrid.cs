using System.Collections.Generic;

namespace GameOfLife.Core
{
    public class PositionInGrid
    {
        public PositionInGrid()
        {
            row = 0;
            column = 0;
        }

        public PositionInGrid(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public int row { get; private set; }
        public int column { get; private set; }

        public int ToScalarForGridOfSize(int size)
        {
            return row*size + column;
        }

        public static PositionInGrid FromScalarForGridOfSize(int scalar, int size)
        {
            return new PositionInGrid(scalar / size, scalar % size);
        }

        public bool IsOutOfBoundsForGridOfSize(int size)
        {
            return row < 0 || row >= size || column < 0 || column >= size;
        }

        public PositionInGrid NorthernNeighbor()
        {
            return new PositionInGrid(row - 1, column);
        }

        public PositionInGrid NorthwesternNeighbor()
        {
            return new PositionInGrid(row - 1, column - 1);
        }

        public PositionInGrid WesternNeighbor()
        {
            return new PositionInGrid(row, column - 1);
        }

        public PositionInGrid SouthwesternNeighbor()
        {
            return new PositionInGrid(row + 1, column - 1);
        }

        public PositionInGrid SouthernNeighbor()
        {
            return new PositionInGrid(row + 1, column);
        }

        public PositionInGrid SoutheasternNeighbor()
        {
            return new PositionInGrid(row + 1, column + 1);
        }

        public PositionInGrid EasternNeighbor()
        {
            return new PositionInGrid(row, column + 1);
        }

        public PositionInGrid NortheasternNeighbor()
        {
            return new PositionInGrid(row - 1, column + 1);
        }

        public IEnumerable<PositionInGrid> Neighbors()
        {
            yield return NorthernNeighbor();
            yield return NortheasternNeighbor();
            yield return EasternNeighbor();
            yield return SoutheasternNeighbor();
            yield return SouthernNeighbor();
            yield return SouthwesternNeighbor();
            yield return WesternNeighbor();
            yield return NorthwesternNeighbor();
        }
    }
}
