namespace Lemonade.Application.Models;

public class CustomerModel
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string PhoneNumber { get; set; }

    public IEnumerable<OrderModel> Orders { get; set; }
}