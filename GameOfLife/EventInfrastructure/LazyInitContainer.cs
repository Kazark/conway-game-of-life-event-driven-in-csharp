using System.Collections.Generic;

namespace GameOfLife.EventInfrastructure
{
    public class LazyInitContainer
    {
        public T GetInstanceOf<T>() where T : class
        {
            return null;
        }
    }
}
