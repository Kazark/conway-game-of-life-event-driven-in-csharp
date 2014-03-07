namespace GameOfLife.Events
{
    public interface IGrid<out T>
    {
        T cellAt(PositionInGrid position);
    }
}