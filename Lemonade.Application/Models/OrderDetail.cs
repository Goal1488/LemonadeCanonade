namespace Lemonade.Application.Models;

public class OrderDetailModel
{
    public Guid Id { get; set; }
    
    public int Quantity { get; set; }
    public LemonadeSizeModel Size { get; set; }
    public int Price { get; set; }
    
    public Guid LemonadeId { get; set; }
    public Guid OrderId { get; set; }
}