namespace DotnetRelations.APIs.Dtos;

public class OrderUpdateInput
{
    public string? Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? Date { get; set; }

    public string? Customer { get; set; }
}
