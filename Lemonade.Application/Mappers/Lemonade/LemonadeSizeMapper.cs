using Lemonade.Application.Models;
using Lemonade.Domain.Entities;

namespace Lemonade.Application.Mappers.Lemonade;

public static class LemonadeSizeMapper
{
    public static LemonadeSizeModel Map(this LemonadeSize input)
    {
        if (input == null)
        {
            return null;
        }

        var result = new LemonadeSizeModel
        {
            Id = input.Id,
            Size = input.Size,
            Price = input.Price,
            LemonadeId = input.LemonadeId
        };

        return result;
    }
}