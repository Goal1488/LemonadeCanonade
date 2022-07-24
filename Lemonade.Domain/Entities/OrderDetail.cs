namespace Lemonade.Domain.Entities;

public class OrderDetail : IEntity
{
    public Guid Id { get; set; }
    
    public int Quantity { get; set; }
    public LemonadeSize Size { get; set; }
    public int Price { get; set; }
    
    public Guid LemonadeId { get; set; }
    public int OrderId { get; set; }
}