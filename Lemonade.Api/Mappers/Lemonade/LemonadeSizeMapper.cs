using Lemonade.Api.ViewModels.Lemonade;
using Lemonade.Application.Models;

namespace Lemonade.Api.Mappers.Lemonade;

public static class LemonadeSizeMapper
{
    public static LemonadeSizeViewModel Map(this LemonadeSizeModel input)
    {
        if (input == null)
        {
            return null;
        }

        var result = new LemonadeSizeViewModel
        {
            Id = input.Id,
            Size = input.Size,
            Price = input.Price,
            LemonadeId = input.LemonadeId,
        };

        return result;
    }
}