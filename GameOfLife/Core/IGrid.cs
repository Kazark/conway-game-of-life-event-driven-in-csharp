namespace GameOfLife.Core
{
    public interface IGrid<out T>
    {
        T cellAt(PositionInGrid position);
    }
}