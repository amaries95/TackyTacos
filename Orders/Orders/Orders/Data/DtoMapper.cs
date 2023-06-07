using Kitchen.Contracts;
using Kitchen.Contracts.Dtos;
using Orders.Contracts.Dtos;
using Orders.Entities;
using Orders.Models;

namespace Orders.Data;

internal static class DtoMapper
{
    internal static OrderDto MapOrder(this OrderDto dto, Order order)
    {

        dto.Id = order.Id;
        dto.CustomerName = order.CustomerName;
        dto.CustomerEmail = order.CustomerEmail;
        dto.TotalPrice = order.TotalPrice;
        dto.OrderStatuses = order.OrderStatuses.Select(os => new OrderStatusUpdateDto().MapOrderStatusUpdate(os)).ToList();
        dto.OrderItems = order.OrderItems.Select(oi => new OrderItemDto().MapOrderItem(oi)).ToList();
        return dto;
    }

    internal static OrderStatusUpdateDto MapOrderStatusUpdate(this OrderStatusUpdateDto dto, OrderStatusUpdate orderStatusUpdate)
    {
        dto.Status = orderStatusUpdate.Status;
        dto.UpdatedTime = orderStatusUpdate.UpdatedTime;
        return dto;
    }

    internal static OrderItemDto MapOrderItem(this OrderItemDto dto, OrderItem orderItem)
    {
        dto.Id = orderItem.Id;
        dto.Name = orderItem.Name;
        dto.Price = orderItem.Price;
        dto.Modifications = orderItem.Modifications.Count() == 0 ? new()
                            : orderItem.Modifications.Select(m => new OrderItemDto().MapOrderItem(m)).ToList();
        return dto;
    }

    internal static Order MapOrderDto(this Order entity, OrderDto dto)
    {

        entity.Id = dto.Id;
        entity.CustomerName = dto.CustomerName;
        entity.CustomerEmail = dto.CustomerEmail;
        entity.TotalPrice = dto.TotalPrice;
        entity.OrderStatuses = dto.OrderStatuses.Select(os => new OrderStatusUpdate().MapOrderStatusUpdateDto(os)).ToList();
        entity.OrderItems = dto.OrderItems.Select(oi => new OrderItem().MapOrderItemDto(oi)).ToList();
        return entity;
    }

    internal static OrderStatusUpdate MapOrderStatusUpdateDto(this OrderStatusUpdate entity, OrderStatusUpdateDto dto)
    {
        entity.Status = dto.Status;
        entity.UpdatedTime = dto.UpdatedTime;
        return entity;
    }

    internal static OrderItem MapOrderItemDto(this OrderItem entity, OrderItemDto dto)
    {
        entity.Id = dto.Id;
        entity.Name = dto.Name;
        entity.Price = dto.Price;
        entity.Modifications = dto.Modifications.Count() == 0 ? new()
                            : dto.Modifications.Select(m => new OrderItem().MapOrderItemDto(m)).ToList();
        return entity;
    }

    internal static KitchenOrderDto MapOrderDto(this KitchenOrderDto dto, OrderDto entity)
    {
        dto.Id = entity.Id;
        dto.OrderStatuses = entity.OrderStatuses.Select(m => new KitchenOrderStatusUpdateDto().MapOrderStatusUpdate(m)).ToList();
        dto.OrderItems = entity.OrderItems.Select(m => new KitchenOrderItemDto().MapOrderItem(m)).ToList();

        return dto;
    }

    internal static KitchenOrderStatusUpdateDto MapOrderStatusUpdate(this KitchenOrderStatusUpdateDto dto, OrderStatusUpdateDto entity)
    {
        if (Enum.TryParse<KitchenOrderStatus>(entity.Status.ToString(), out var status))
        {
            dto.Status = status;
            dto.UpdatedTime = entity.UpdatedTime;
        }

        return dto;
    }
    internal static KitchenOrderItemDto MapOrderItem(this KitchenOrderItemDto dto, OrderItemDto orderItem)
    {
        dto.Name = orderItem.Name;
        dto.Modifications = orderItem.Modifications.Count() == 0 ? new()
                            : orderItem.Modifications.Select(m => new KitchenOrderItemDto().MapOrderItem(m)).ToList();
        return dto;
    }
}
