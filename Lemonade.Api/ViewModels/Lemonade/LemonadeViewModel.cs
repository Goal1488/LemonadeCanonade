namespace Lemonade.Api.ViewModels.Lemonade;

public class LemonadeViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public List<LemonadeSizeViewModel> AvailableSizes { get; set; } = new();
}