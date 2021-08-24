using Mapster;

namespace DanskeBank.Mapper.Mapster
{
    public class MapsterMapper : IMap
    {
        public TDestination Map<TDestination>(object source)
        {
            var mappedObj = source.Adapt<TDestination>();
            return mappedObj;
        }
    }
}
