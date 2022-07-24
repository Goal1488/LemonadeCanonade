using Lemonade.Domain.Shared;

namespace Lemonade.Application.Models;

public class LemonadeSizeModel
{
    public Guid Id { get; set; }
    public Guid LemonadeId { get; set; }
    
    public LemonadeModel Lemonade { get; set; }

    public LemonadeSizeModel(LemonadeSizeEnum size, int price)
    {
        Size = size;
        Price = price;
    }

    public LemonadeSizeEnum Size { get; private set; }

    public int Price { get; set; }
}