namespace Web.Infrastructure
{
    
    public interface IConverter<TDestination, TSource> 
    {
        TDestination Convert(TSource value); 
    }
}