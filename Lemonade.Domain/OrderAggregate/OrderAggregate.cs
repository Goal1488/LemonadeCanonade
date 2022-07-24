namespace Lemonade.Domain.OrderAggregate;

public class OrderAggregate
{
    public int Id { get; set; }
    
    public int CustomerId { get; set; }
    
    public  ICollection<OrderDetail> OrderDetails { get; set; }
}