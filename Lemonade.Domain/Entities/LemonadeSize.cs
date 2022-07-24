using Lemonade.Domain.Shared;

namespace Lemonade.Domain.Entities;

public class LemonadeSize : IEntity
{
    public Guid Id { get; set; }
    public Guid LemonadeId { get; set; }
    public Lemonade Lemonade { get; set; }

    public LemonadeSize(LemonadeSizeEnum size, int price)
    {
        Size = size;
        Price = price;
    }

    public LemonadeSizeEnum Size { get; private set; }

    public int Price { get; set; }
}