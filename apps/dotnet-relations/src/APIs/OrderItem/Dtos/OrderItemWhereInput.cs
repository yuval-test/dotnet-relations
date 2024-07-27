namespace DotnetRelations.APIs.Dtos;

public class OrderItemWhereInput
{
    public string? Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Order { get; set; }

    public int? Quantity { get; set; }

    public double? Price { get; set; }

    public string? Customer { get; set; }

    public string? AnotherCustomer { get; set; }
}
