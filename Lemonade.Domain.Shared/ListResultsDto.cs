namespace Lemonade.Domain.Shared;

public class ListResultsDto<T>
{
    public List<T> Items { get; set; }
    public int TotalCount { get; set; }
}