namespace Lemonade.Api.ViewModels.Lemonade;

public class LemonadeCreateViewModel
{
    public string Name { get; set; }

    public List<LemonadeSizeCreateViewModel> AvailableSizes { get; set; } = new();
}