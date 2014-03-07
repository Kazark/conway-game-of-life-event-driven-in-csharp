namespace GameOfLife.Core
{
    public interface IGrid<out T>
    {
        T CellAt(PositionInGrid position);
    }
}