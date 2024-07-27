using DotnetRelations.APIs.Common;
using DotnetRelations.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetRelations.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class OrderItemFindManyArgs : FindManyInput<OrderItem, OrderItemWhereInput> { }
