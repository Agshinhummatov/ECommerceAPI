using E_CommerceAPI.Application.Abstractions.Services;
using E_CommerceAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAPI.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductsQueryRequest, GetAllProductsQueryResponse>
    {

        private readonly IProductService _productService;

        public GetAllProductQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {

            var productList = await _productService.GetAllProductAsync(request.Page, request.Size);

            return new GetAllProductsQueryResponse
            {
                Products = productList.Products,
                TotalProductCount = productList.TotalProductCount
            };
        }
      
    }
}
