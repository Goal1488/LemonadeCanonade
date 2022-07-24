using Lemonade.Application.Mappers.Order;
using Lemonade.Application.Models;

namespace Lemonade.Application.Mappers.Customer;

public class CustomerMapper : IMapper<Domain.Entities.Customer, CustomerModel>
{
    public CustomerModel Map(Domain.Entities.Customer source)
    {
        return source.Map();
    }
}

internal static class CustomerExtensions
{
    public static CustomerModel Map(this Domain.Entities.Customer input)
    {
        var result = new CustomerModel
        {
            Id = input.Id,
            Name = input.Name,
            Orders = input.Orders.Select(x => x.Map()),
            PhoneNumber = input.PhoneNumber
        };

        return result;
    }
}