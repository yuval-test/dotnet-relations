using Microsoft.AspNetCore.Mvc;

namespace DotnetRelations.APIs;

[ApiController()]
public class OrdersController : OrdersControllerBase
{
    public OrdersController(IOrdersService service)
        : base(service) { }
}
