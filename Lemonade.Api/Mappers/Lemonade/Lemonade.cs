using Lemonade.Api.ViewModels.Lemonade;
using Lemonade.Application.Mappers;
using Lemonade.Application.Models;

namespace Lemonade.Api.Mappers.Lemonade;

public class LemonadeMapper : IMapper<LemonadeModel, LemonadeViewModel>
{
    public LemonadeViewModel Map(LemonadeModel source)
    {
        return source.Map();
    }
}

public static class LemonadeExtensions
{
    public static LemonadeViewModel Map(this LemonadeModel input)
    {
        if (input == null)
        {
            return null;
        }

        var result = new LemonadeViewModel
        {
            Id = input.Id,
            Name = input.Name,
            AvailableSizes = input.AvailableSizes.Select(x => x.Map()).ToList()
        };

        return result;
    }
    
    public static LemonadeModel Map(this LemonadeViewModel input)
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