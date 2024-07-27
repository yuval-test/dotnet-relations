using Microsoft.AspNetCore.Mvc;

namespace DotnetRelations.APIs;

[ApiController()]
public class CustomersController : CustomersControllerBase
{
    public CustomersController(ICustomersService service)
        : base(service) { }
}
