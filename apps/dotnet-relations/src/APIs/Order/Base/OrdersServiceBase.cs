using DotnetRelations.APIs;
using DotnetRelations.APIs.Common;
using DotnetRelations.APIs.Dtos;
using DotnetRelations.APIs.Errors;
using DotnetRelations.APIs.Extensions;
using DotnetRelations.Infrastructure;
using DotnetRelations.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetRelations.APIs;

public abstract class OrdersServiceBase : IOrdersService
{
    protected readonly DotnetRelationsDbContext _context;

    public OrdersServiceBase(DotnetRelationsDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Order
    /// </summary>
    public async Task<Order> CreateOrder(OrderCreateInput createDto)
    {
        var order = new OrderDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt,
            Date = createDto.Date
        };

        if (createDto.Id != null)
        {
            order.Id = createDto.Id;
        }
        if (createDto.Customer != null)
        {
            order.Customer = await _context
                .Customers.Where(customer => createDto.Customer.Id == customer.Id)
                .FirstOrDefaultAsync();
        }

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<OrderDbModel>(order.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Order
    /// </summary>
    public async Task DeleteOrder(OrderWhereUniqueInput uniqueId)
    {
        var order = await _context.Orders.FindAsync(uniqueId.Id);
        if (order == null)
        {
            throw new NotFoundException();
        }

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Orders
    /// </summary>
    public async Task<List<Order>> Orders(OrderFindManyArgs findManyArgs)
    {
        var orders = await _context
            .Orders.Include(x => x.Customer)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return orders.ConvertAll(order => order.ToDto());
    }

    /// <summary>
    /// Get one Order
    /// </summary>
    public async Task<Order> Order(OrderWhereUniqueInput uniqueId)
    {
        var orders = await this.Orders(
            new OrderFindManyArgs { Where = new OrderWhereInput { Id = uniqueId.Id } }
        );
        var order = orders.FirstOrDefault();
        if (order == null)
        {
            throw new NotFoundException();
        }

        return order;
    }

    /// <summary>
    /// Get a Customer record for Order
    /// </summary>
    public async Task<Customer> GetCustomer(OrderWhereUniqueInput uniqueId)
    {
        var order = await _context
            .Orders.Where(order => order.Id == uniqueId.Id)
            .Include(order => order.Customer)
            .FirstOrDefaultAsync();
        if (order == null)
        {
            throw new NotFoundException();
        }
        return order.Customer.ToDto();
    }

    /// <summary>
    /// Meta data about Order records
    /// </summary>
    public async Task<MetadataDto> OrdersMeta(OrderFindManyArgs findManyArgs)
    {
        var count = await _context.Orders.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Update one Order
    /// </summary>
    public async Task UpdateOrder(OrderWhereUniqueInput uniqueId, OrderUpdateInput updateDto)
    {
        var order = updateDto.ToModel(uniqueId);

        _context.Entry(order).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Orders.Any(e => e.Id == order.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
