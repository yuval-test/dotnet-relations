using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetRelations.Infrastructure.Models;

[Table("Customers")]
public class CustomerDbModel
{
    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    [StringLength(1000)]
    public string? Name { get; set; }

    [StringLength(1000)]
    public string? Phone { get; set; }

    public List<OrderDbModel>? Orders { get; set; } = new List<OrderDbModel>();
}
