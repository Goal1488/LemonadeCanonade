using Lemonade.Domain.Shared;

namespace Lemonade.Api.ViewModels.Lemonade;

public class LemonadeSizeViewModel
{
    public Guid Id { get; set; }
    public Guid LemonadeId { get; set; }

    public LemonadeSizeEnum Size { get; set; }

    public int Price { get; set; }
}