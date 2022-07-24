using Lemonade.Api.ViewModels.Order;

namespace Lemonade.Api.ViewModels.Customer;

public class CustomerCreateViewModel
{
    public string Name { get; set; }
    
    public string PhoneNumber { get; set; }

    public IEnumerable<OrderViewModel> Orders { get; set; }
}