
using E_CommerceAPI.Application.Abstractions.Services;
using E_CommerceAPI.Application.DTOs.Product;
using E_CommerceAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAPI.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequset, CreateProductCommandResponse>
    {
        private readonly IProductService _productService;

        public CreateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequset request, CancellationToken cancellationToken)
        {
            var productDto = new ProductDTO
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock
            };

            await _productService.CreateProductAsync(productDto);

            return new CreateProductCommandResponse();
        }

    }
}
