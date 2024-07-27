using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetRelations.Infrastructure.Models;

[Table("Orders")]
public class OrderDbModel
{
    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public DateTime? Date { get; set; }

    public string CustomerId { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public CustomerDbModel Customer { get; set; } = null;

    public List<OrderItemDbModel>? OrderItems { get; set; } = new List<OrderItemDbModel>();
}
