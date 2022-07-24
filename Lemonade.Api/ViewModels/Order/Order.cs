using Lemonade.Api.ViewModels.Customer;

namespace Lemonade.Api.ViewModels.Order;

public class OrderViewModel
{
    public OrderViewModel()
    {
    }

    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public CustomerViewModel Customer { get; set; }

    public ICollection<OrderDetailViewModel> OrderDetails { get; set; }
}