namespace DotnetRelations.APIs.Dtos;

public class CustomerCreateInput
{
    public string? Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public List<Order> Orders { get; set; }

    public List<OrderItem>? OrderItems { get; set; }

    public List<OrderItem>? AnotherOrderItem { get; set; }
}
