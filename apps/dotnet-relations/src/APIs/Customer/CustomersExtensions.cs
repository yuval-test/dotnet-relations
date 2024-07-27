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
        };
    }

    public static CustomerDbModel ToModel(
        this CustomerUpdateInput updateDto,
        CustomerWhereUniqueInput uniqueId
    )
    {
        var customer = new CustomerDbModel { Id = uniqueId.Id };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            customer.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            customer.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.Name != null)
        {
            customer.Name = updateDto.Name;
        }
        if (updateDto.Phone != null)
        {
            customer.Phone = updateDto.Phone;
        }
        if (updateDto.Orders != null)
        {
            customer.Orders = updateDto.Orders.Value;
        }

        return customer;
    }
}
