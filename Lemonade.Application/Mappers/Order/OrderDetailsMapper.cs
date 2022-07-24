using Lemonade.Application.Mappers.Lemonade;
using Lemonade.Application.Models;
using Lemonade.Domain.Entities;

namespace Lemonade.Application.Mappers.Order;

public static class OrderDetailsMapper
{
    public static OrderDetailModel Map(this OrderDetail input)
    {
        if (input == null)
        {
            return null;
        }

        var result = new OrderDetailModel
        {
            Id = input.Id,
            Quantity = input.Quantity,
            Size = input.Size.Map(),
            Price = input.Price,
            LemonadeId = input.LemonadeId,
            OrderId = input.OrderId,
        };

        return result;
    }
}