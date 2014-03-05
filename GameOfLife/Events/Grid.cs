namespace GameOfLife.Events
{
    public class Grid
    {
        private int _size;

        public Grid(int size)
        {
            _size = size;
        }

        public int Size
        {
            get { return _size; }
        }
    }
}
