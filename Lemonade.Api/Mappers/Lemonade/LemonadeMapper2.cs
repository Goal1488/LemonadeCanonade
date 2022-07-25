using Lemonade.Api.ViewModels.Lemonade;
using Lemonade.Application.Mappers;
using Lemonade.Application.Models;

namespace Lemonade.Api.Mappers.Lemonade;

public class LemonadeMapper2 : IMapper<LemonadeViewModel, LemonadeModel>
{
    public LemonadeModel Map(LemonadeViewModel source)
    {
        return source.Map();
    }
}