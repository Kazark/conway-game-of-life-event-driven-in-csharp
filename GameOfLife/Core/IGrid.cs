namespace GameOfLife.Core
{
    public interface IGrid<T>
    {
        Cell<T> CellAt(PositionInGrid position);
    }
}