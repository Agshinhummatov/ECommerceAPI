using E_CommerceAPI.Application.Abstractions.Services;
using E_CommerceAPI.Application.DTOs.Product;
using E_CommerceAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAPI.Application.Features.Queries.Product.SearchProducts
{
    public class SearchProductsQueryHandler : IRequestHandler<SearchProductsQueryRequest, SearchProductsQueryResponse>
    {
        private readonly IProductService _productService;

        public SearchProductsQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<SearchProductsQueryResponse> Handle(SearchProductsQueryRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                throw new ArgumentException("Search term cannot be empty", nameof(request.SearchTerm));
            }

            IEnumerable<ProductDTO> products = await _productService.SearchProductsAsync(request.SearchTerm);

            return new SearchProductsQueryResponse { Products = products };
        }
    }
}
