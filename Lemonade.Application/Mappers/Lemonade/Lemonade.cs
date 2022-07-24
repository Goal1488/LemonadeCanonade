using Lemonade.Application.Models;

namespace Lemonade.Application.Mappers.Lemonade;

public class LemonadeMapper : IMapper<Domain.Entities.Lemonade, LemonadeModel>
{
    public LemonadeModel Map(Domain.Entities.Lemonade source)
    {
        return source.Map();
    }       
}
    
public static class LemonadeExtensions
{
    public static LemonadeModel Map(this Domain.Entities.Lemonade input)
    {
        if (input == null)
        {
            return null;
        }

        var result = new LemonadeModel
        {
            Id = input.Id,
            Name = input.Name,
            AvailableSizes = input.AvailableSizes.Select(x => x.Map()).ToList()
        };

        return result;
    }
}