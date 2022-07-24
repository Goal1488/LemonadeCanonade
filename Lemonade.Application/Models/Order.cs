namespace Lemonade.Application.Models;

public class OrderModel
{
    public OrderModel()
    {
    }

    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public CustomerModel Customer { get; set; }

    public ICollection<OrderDetailModel> OrderDetails { get; set; }
}