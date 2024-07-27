using DotnetRelations.Infrastructure;

namespace DotnetRelations.APIs;

public class OrdersService : OrdersServiceBase
{
    public OrdersService(DotnetRelationsDbContext context)
        : base(context) { }
}
