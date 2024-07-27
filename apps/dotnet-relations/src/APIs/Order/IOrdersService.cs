using DotnetRelations.APIs.Common;
using DotnetRelations.APIs.Dtos;

namespace DotnetRelations.APIs;

public interface IOrdersService
{
    /// <summary>
    /// Create one Order
    /// </summary>
    public Task<Order> CreateOrder(OrderCreateInput order);

    /// <summary>
    /// Delete one Order
    /// </summary>
    public Task DeleteOrder(OrderWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Orders
    /// </summary>
    public Task<List<Order>> Orders(OrderFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Order
    /// </summary>
    public Task<Order> Order(OrderWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Customer record for Order
    /// </summary>
    public Task<Customer> GetCustomer(OrderWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Order records
    /// </summary>
    public Task<MetadataDto> OrdersMeta(OrderFindManyArgs findManyArgs);

    /// <summary>
    /// Update one Order
    /// </summary>
    public Task UpdateOrder(OrderWhereUniqueInput uniqueId, OrderUpdateInput updateDto);
}
