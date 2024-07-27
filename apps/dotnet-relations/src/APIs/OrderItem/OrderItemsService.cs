using DotnetRelations.Infrastructure;

namespace DotnetRelations.APIs;

public class OrderItemsService : OrderItemsServiceBase
{
    public OrderItemsService(DotnetRelationsDbContext context)
        : base(context) { }
}
