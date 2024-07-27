using DotnetRelations.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetRelations.Infrastructure;

public class DotnetRelationsDbContext : DbContext
{
    public DotnetRelationsDbContext(DbContextOptions<DotnetRelationsDbContext> options)
        : base(options) { }

    public DbSet<CustomerDbModel> Customers { get; set; }

    public DbSet<OrderDbModel> Orders { get; set; }

    public DbSet<OrderItemDbModel> OrderItems { get; set; }
}
