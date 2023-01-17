using MediatR;

namespace BookShop.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : OrderDto, IRequest<string>
    {
    }
}
