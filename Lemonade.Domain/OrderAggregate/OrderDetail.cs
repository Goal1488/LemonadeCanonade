namespace Lemonade.Domain.OrderAggregate;

public class OrderDetail
{
    public int Id { get; set; }
    
    public int Quantity { get; set; }
    public LemonadeSize Size { get; set; }
    public int Price { get; set; }
    
    public int LemonadeId { get; set; }
    public int OrderId { get; set; }
}