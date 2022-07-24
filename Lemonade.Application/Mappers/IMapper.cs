namespace Lemonade.Application.Mappers;

public interface IMapper<TSource, TDestanation>
{
    TDestanation Map(TSource source);
}