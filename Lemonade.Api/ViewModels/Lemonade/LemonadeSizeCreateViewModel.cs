using Lemonade.Domain.Shared;

namespace Lemonade.Api.ViewModels.Lemonade;

public class LemonadeSizeCreateViewModel
{
    public LemonadeSizeEnum Size { get; set; }
    public int Price { get; set; }
}