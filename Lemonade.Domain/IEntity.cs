namespace Lemonade.Domain;

public interface IEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedOn { get; set; }
}