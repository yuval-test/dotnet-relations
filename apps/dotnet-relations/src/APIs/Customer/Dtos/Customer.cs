namespace DotnetRelations.APIs.Dtos;

public class Customer
{
    public string Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public List<string> Orders { get; set; }

    public List<string>? OrderItems { get; set; }

    public string? AnotherOrderItem { get; set; }
}
