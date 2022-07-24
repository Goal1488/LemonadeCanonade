using Lemonade.Domain;
using Lemonade.Domain.Shared;

namespace Lemonade.Application.Models;

public class LemonadeModel 
{
    public LemonadeModel(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public Guid Id { get; set; }
    public string Name { get; private set; }

    public List<LemonadeSizeModel> AvailableSizes { get; private set; } = new();

}