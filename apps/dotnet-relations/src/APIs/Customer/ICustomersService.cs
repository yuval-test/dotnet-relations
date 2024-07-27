using DotnetRelations.APIs.Common;
using DotnetRelations.APIs.Dtos;

namespace DotnetRelations.APIs;

public interface ICustomersService
{
    /// <summary>
    /// Create one customer
    /// </summary>
    public Task<Customer> CreateCustomer(CustomerCreateInput customer);

    /// <summary>
    /// Connect multiple AnotherOrderItem records to customer
    /// </summary>
    public Task ConnectAnotherOrderItem(
        CustomerWhereUniqueInput uniqueId,
        OrderItemWhereUniqueInput[] orderItemsId
    );

    /// <summary>
    /// Connect multiple OrderItems records to customer
    /// </summary>
    public Task ConnectOrderItems(
        CustomerWhereUniqueInput uniqueId,
        OrderItemWhereUniqueInput[] orderItemsId
    );

    /// <summary>
    /// Connect multiple Orders records to customer
    /// </summary>
    public Task ConnectOrders(CustomerWhereUniqueInput uniqueId, OrderWhereUniqueInput[] ordersId);

    /// <summary>
    /// Disconnect multiple AnotherOrderItem records from customer
    /// </summary>
    public Task DisconnectAnotherOrderItem(
        CustomerWhereUniqueInput uniqueId,
        OrderItemWhereUniqueInput[] orderItemsId
    );

    /// <summary>
    /// Disconnect multiple OrderItems records from customer
    /// </summary>
    public Task DisconnectOrderItems(
        CustomerWhereUniqueInput uniqueId,
        OrderItemWhereUniqueInput[] orderItemsId
    );

    /// <summary>
    /// Disconnect multiple Orders records from customer
    /// </summary>
    public Task DisconnectOrders(
        CustomerWhereUniqueInput uniqueId,
        OrderWhereUniqueInput[] ordersId
    );

    /// <summary>
    /// Find multiple AnotherOrderItem records for customer
    /// </summary>
    public Task<List<OrderItem>> FindAnotherOrderItem(
        CustomerWhereUniqueInput uniqueId,
        OrderItemFindManyArgs OrderItemFindManyArgs
    );

    /// <summary>
    /// Find multiple OrderItems records for customer
    /// </summary>
    public Task<List<OrderItem>> FindOrderItems(
        CustomerWhereUniqueInput uniqueId,
        OrderItemFindManyArgs OrderItemFindManyArgs
    );

    /// <summary>
    /// Find multiple Orders records for customer
    /// </summary>
    public Task<List<Order>> FindOrders(
        CustomerWhereUniqueInput uniqueId,
        OrderFindManyArgs OrderFindManyArgs
    );

    /// <summary>
    /// Meta data about customer records
    /// </summary>
    public Task<MetadataDto> CustomersMeta(CustomerFindManyArgs findManyArgs);

    /// <summary>
    /// Update multiple AnotherOrderItem records for customer
    /// </summary>
    public Task UpdateAnotherOrderItem(
        CustomerWhereUniqueInput uniqueId,
        OrderItemWhereUniqueInput[] orderItemsId
    );

    /// <summary>
    /// Update multiple OrderItems records for customer
    /// </summary>
    public Task UpdateOrderItems(
        CustomerWhereUniqueInput uniqueId,
        OrderItemWhereUniqueInput[] orderItemsId
    );

    /// <summary>
    /// Update multiple Orders records for customer
    /// </summary>
    public Task UpdateOrders(CustomerWhereUniqueInput uniqueId, OrderWhereUniqueInput[] ordersId);

    /// <summary>
    /// Delete one customer
    /// </summary>
    public Task DeleteCustomer(CustomerWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many customers
    /// </summary>
    public Task<List<Customer>> Customers(CustomerFindManyArgs findManyArgs);

    /// <summary>
    /// Update one customer
    /// </summary>
    public Task UpdateCustomer(CustomerWhereUniqueInput uniqueId, CustomerUpdateInput updateDto);
}
