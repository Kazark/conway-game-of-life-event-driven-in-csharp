using System;
using System.Linq;
using GameOfLife.EventInfrastructure;

namespace GameOfLife
{
    public class WireUpDependencies
    {
        public void WireThemUp()
        {
            var router = new Router();
            var channel = new Channel(router);
            var assembly = GetType().Assembly;
            var inheritors = from type in assembly.GetTypes()
                             where typeof(IConsume<>).IsAssignableFrom(type) && type.IsClass
                             select type;
            foreach (var type in inheritors)
            {
                var constructor = type.GetConstructors().First();
                var parameters = constructor.GetParameters().Select(p => channel);
                object[] parameterArray;
                try
                {
                    parameterArray = parameters.ToArray();
                }
                catch (Exception)
                {
                    continue;
                }
                var instance = constructor.Invoke(parameterArray);
                var genericParameterType = type.GetGenericArguments().First();
                router.RegisterHandlerForType(instance, genericParameterType);
            }
        }
    }
}
