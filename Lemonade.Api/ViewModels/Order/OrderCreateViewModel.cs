using Lemonade.Api.ViewModels.Customer;

namespace Lemonade.Api.ViewModels.Order;

public class OrderCreateViewModel
{
    public OrderCreateViewModel()
    {
    }

    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public CustomerViewModel Customer { get; set; }

    public ICollection<OrderDetailViewModel> OrderDetails { get; set; }
}