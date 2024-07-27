namespace DotnetRelations.APIs.Dtos;

public class OrderItemCreateInput
{
    public string? Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Order? Order { get; set; }

    public int? Quantity { get; set; }

    public double? Price { get; set; }

    public Customer Customer { get; set; }

    public Customer? AnotherCustomer { get; set; }
}
