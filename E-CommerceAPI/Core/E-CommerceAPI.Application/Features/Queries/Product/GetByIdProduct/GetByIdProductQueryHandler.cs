using E_CommerceAPI.Application.Abstractions.Services;
using E_CommerceAPI.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAPI.Application.Features.Queries.Product.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly IProductService _productService;

        public GetByIdProductQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var productDto = await _productService.GetByIdAsync(request.Id);

            if (productDto == null)
            {
                
                throw new NotFoundException($"Product {request.Id} not found");
            }
            var response = new GetByIdProductQueryResponse
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Price = productDto.Price,
                Stock = productDto.Stock,
                Description = productDto.Description,
                CreatedDate = productDto.CreatedDate,
                UpdatedDate = productDto.UpdatedDate,
                ProductImageFiles = productDto.ProductImageFiles
            };

            return response;
        }


    }
}
