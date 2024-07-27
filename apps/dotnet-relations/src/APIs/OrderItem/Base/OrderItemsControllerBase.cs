using DotnetRelations.APIs;
using DotnetRelations.APIs.Common;
using DotnetRelations.APIs.Dtos;
using DotnetRelations.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace DotnetRelations.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class OrderItemsControllerBase : ControllerBase
{
    protected readonly IOrderItemsService _service;

    public OrderItemsControllerBase(IOrderItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one OrderItem
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<OrderItem>> CreateOrderItem(OrderItemCreateInput input)
    {
        var orderItem = await _service.CreateOrderItem(input);

        return CreatedAtAction(nameof(OrderItem), new { id = orderItem.Id }, orderItem);
    }

    /// <summary>
    /// Delete one OrderItem
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteOrderItem(
        [FromRoute()] OrderItemWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteOrderItem(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many OrderItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<OrderItem>>> OrderItems(
        [FromQuery()] OrderItemFindManyArgs filter
    )
    {
        return Ok(await _service.OrderItems(filter));
    }

    /// <summary>
    /// Get one OrderItem
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<OrderItem>> OrderItem(
        [FromRoute()] OrderItemWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.OrderItem(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Get a Customer record for OrderItem
    /// </summary>
    [HttpGet("{Id}/customers")]
    public async Task<ActionResult<List<Customer>>> GetCustomer(
        [FromRoute()] OrderItemWhereUniqueInput uniqueId
    )
    {
        var customer = await _service.GetCustomer(uniqueId);
        return Ok(customer);
    }

    /// <summary>
    /// Get a Order record for OrderItem
    /// </summary>
    [HttpGet("{Id}/orders")]
    public async Task<ActionResult<List<Order>>> GetOrder(
        [FromRoute()] OrderItemWhereUniqueInput uniqueId
    )
    {
        var order = await _service.GetOrder(uniqueId);
        return Ok(order);
    }

    /// <summary>
    /// Meta data about OrderItem records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> OrderItemsMeta(
        [FromQuery()] OrderItemFindManyArgs filter
    )
    {
        return Ok(await _service.OrderItemsMeta(filter));
    }

    /// <summary>
    /// Update one OrderItem
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateOrderItem(
        [FromRoute()] OrderItemWhereUniqueInput uniqueId,
        [FromQuery()] OrderItemUpdateInput orderItemUpdateDto
    )
    {
        try
        {
            await _service.UpdateOrderItem(uniqueId, orderItemUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
