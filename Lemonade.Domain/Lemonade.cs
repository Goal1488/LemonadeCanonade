using Lemonade.Domain.Shared;

namespace Lemonade.Domain;

public class Lemonade : IAggregateRoot
{
    public Lemonade(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public int Id { get; set; }

    public string Name { get; private set; }

    public List<LemonadeSize> AvailableSizes { get; private set; } = new();

    public void SetSize(LemonadeSizeEnum sizeEnum, int price)
    {
        var lemonadeSize = AvailableSizes.FirstOrDefault(x => x.Size == sizeEnum);

        if (lemonadeSize != null)
        {
            lemonadeSize.Price = price;
        }
        else
        {
            AvailableSizes.Add(new LemonadeSize(sizeEnum, price));
        }
    }
}