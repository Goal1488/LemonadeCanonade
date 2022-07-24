using Lemonade.Domain.Shared;

namespace Lemonade.Domain;

public class LemonadeSize
{
    public int Id { get; set; }

    public LemonadeSize(LemonadeSizeEnum size, int price)
    {
        Size = size;
        Price = price;
    }

    public LemonadeSizeEnum Size { get; private set; }

    public int Price { get; set; }
}