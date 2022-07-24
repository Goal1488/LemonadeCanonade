namespace Lemonade.Application.Models;

public class LemonadeModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public List<LemonadeSizeModel> AvailableSizes { get; set; } = new();
}