namespace Lemonade.Domain.Entities;

public class Customer : IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedOn { get; set; }

    public string Name { get; set; }
    
    public string PhoneNumber { get; set; }

    public IEnumerable<Order> Orders { get; set; }
}