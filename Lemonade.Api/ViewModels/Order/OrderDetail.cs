using Lemonade.Api.ViewModels.Lemonade;

namespace Lemonade.Api.ViewModels.Order;

public class OrderDetailViewModel
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public LemonadeSizeViewModel Size { get; set; }
    public int Price { get; set; }
    public Guid LemonadeId { get; set; }
    public Guid OrderId { get; set; }
}