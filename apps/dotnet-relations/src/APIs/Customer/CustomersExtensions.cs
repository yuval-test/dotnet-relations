using DotnetRelations.APIs.Dtos;
using DotnetRelations.Infrastructure.Models;

namespace DotnetRelations.APIs.Extensions;

public static class CustomersExtensions
{
    public static Customer ToDto(this CustomerDbModel model)
    {
        return new Customer
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            Name = model.Name,
            Phone = model.Phone,
            Orders = model.Orders?.Select(x => x.Id).ToList(),
            OrderItems = model.OrderItems?.Select(x => x.Id).ToList(),
            AnotherOrderItem = model.OrderItems?.ToDto(),
        };
    }

    public static CustomerDbModel ToModel(
        this CustomerUpdateInput updateDto,
        CustomerWhereUniqueInput uniqueId
    )
    {
        var customer = new CustomerDbModel
        {
            Id = uniqueId.Id,
            Name = updateDto.Name,
            Phone = updateDto.Phone
        };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            customer.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            customer.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return customer;
    }
}
