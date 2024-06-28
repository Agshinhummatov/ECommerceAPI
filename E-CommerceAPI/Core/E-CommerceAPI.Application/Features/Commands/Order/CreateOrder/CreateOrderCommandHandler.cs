using E_CommerceAPI.Application.Abstractions.Services;
using MediatR;


namespace E_CommerceAPI.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        readonly IOrderService _orderService;
        readonly IBasketService _basketService;
      

        public CreateOrderCommandHandler(IOrderService orderService, IBasketService basketService)
        {
            _orderService = orderService;
            _basketService = basketService;
           
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
           await  _orderService.CreateOrderAsync(new()
            {
                Address = request.Address,
                Description = request.Description,
                BasketId = _basketService.GetUserActiveBasket?.Id.ToString()
                
            });

            return new();
            
        }
    }
}
