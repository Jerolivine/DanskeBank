namespace DanskeBank.Mapper
{
    public interface IMap
    {
        TDestination Map<TDestination>(object source);
    }
}
