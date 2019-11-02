namespace Application.Abstraction.Adapters
{
    public interface IAdapter<in TSource, out TDestination>
    {
        TDestination Adapt(TSource source);
    }
}