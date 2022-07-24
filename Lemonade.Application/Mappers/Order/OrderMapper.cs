using Lemonade.Application.Mappers.Customer;
using Lemonade.Application.Models;

namespace Lemonade.Application.Mappers.Order;

public class OrderMapper : IMapper<Domain.Entities.Order, OrderModel>
{
    public OrderModel Map(Domain.Entities.Order source)
    {
        return source.Map();
    }       
}
    
public static class OrderExtensions
{
    public static OrderModel Map(this Domain.Entities.Order input)
    {
        if (input == null)
        {
            return null;
        }

        var result = new OrderModel
        {
            Id = input.Id,
            CustomerId = input.CustomerId,
            Customer = input.Customer.Map(),
            OrderDetails = input.OrderDetails.Select(x => x.Map()).ToList(),
        };

        return result;
    }
}