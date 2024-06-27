using E_CommerceAPI.Application.Abstractions.Services;
using E_CommerceAPI.Application.DTOs.Product;
using E_CommerceAPI.Application.Repositories;
using MediatR;
using P = E_CommerceAPI.Domain.Entities;

namespace E_CommerceAPI.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductService _productService;

        public UpdateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var productUpdateDTO = new ProductUpdateDTO
                {
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                    Stock = request.Stock
                };

                await _productService.UpdateProductAsync(request.Id, productUpdateDTO);
                return new UpdateProductCommandResponse();
            }
            catch (ArgumentException ex)
            {
                throw new Exception("Invalid product ID", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the product", ex);
            }
        }
    }
}
