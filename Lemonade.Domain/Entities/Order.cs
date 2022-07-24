namespace Lemonade.Domain.Entities;

public class Order : IEntity
{
    public Order()
    {
    }

    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public Customer Customer { get; set; }

    public ICollection<OrderDetail> OrderDetails { get; set; }
}