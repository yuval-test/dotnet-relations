using DotnetRelations.Infrastructure;

namespace DotnetRelations.APIs;

public class CustomersService : CustomersServiceBase
{
    public CustomersService(DotnetRelationsDbContext context)
        : base(context) { }
}
