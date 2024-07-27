using DotnetRelations.APIs.Dtos;
using DotnetRelations.Infrastructure.Models;

namespace DotnetRelations.APIs.Extensions;

public static class OrderItemsExtensions
{
    public static OrderItem ToDto(this OrderItemDbModel model)
    {
        return new OrderItem
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            Order = model.OrderId,
            Quantity = model.Quantity,
            Price = model.Price,
            Customer = model.CustomerId,
            AnotherCustomer = model.AnotherCustomerId,
        };
    }

    public static OrderItemDbModel ToModel(
        this OrderItemUpdateInput updateDto,
        OrderItemWhereUniqueInput uniqueId
    )
    {
        var orderItem = new OrderItemDbModel
        {
            Id = uniqueId.Id,
            Quantity = updateDto.Quantity,
            Price = updateDto.Price
        };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            orderItem.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            orderItem.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.Customer != null)
        {
            orderItem.Customer = updateDto.Customer;
        }

        return orderItem;
    }
}
