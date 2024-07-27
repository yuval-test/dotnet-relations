namespace DotnetRelations.APIs.Dtos;

public class OrderItemUpdateInput
{
    public string? Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Order { get; set; }

    public int? Quantity { get; set; }

    public double? Price { get; set; }
}
