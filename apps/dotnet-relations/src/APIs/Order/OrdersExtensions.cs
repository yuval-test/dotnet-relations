using DotnetRelations.APIs.Dtos;
using DotnetRelations.Infrastructure.Models;

namespace DotnetRelations.APIs.Extensions;

public static class OrdersExtensions
{
    public static Order ToDto(this OrderDbModel model)
    {
        return new Order
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            Date = model.Date,
            Customer = model.CustomerId,
        };
    }

    public static OrderDbModel ToModel(
        this OrderUpdateInput updateDto,
        OrderWhereUniqueInput uniqueId
    )
    {
        var order = new OrderDbModel { Id = uniqueId.Id };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            order.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            order.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.Date != null)
        {
            order.Date = updateDto.Date.Value;
        }
        if (updateDto.Customer != null)
        {
            order.Customer = updateDto.Customer;
        }

        return order;
    }
}
