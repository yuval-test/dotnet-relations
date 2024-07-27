using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetRelations.Infrastructure.Models;

[Table("OrderItems")]
public class OrderItemDbModel
{
    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public string? OrderId { get; set; }

    [ForeignKey(nameof(OrderId))]
    public OrderDbModel? Order { get; set; } = null;

    [Range(-999999999, 999999999)]
    public int? Quantity { get; set; }

    [Range(-999999999, 999999999)]
    public double? Price { get; set; }

    public string CustomerItemId { get; set; }

    [ForeignKey(nameof(CustomerItemId))]
    public CustomerDbModel CustomerItem { get; set; } = null;

    public string? AnotherCustomerId { get; set; }

    [ForeignKey(nameof(AnotherCustomerId))]
    public CustomerDbModel? AnotherCustomer { get; set; } = null;
}
