using E_CommerceAPI.Application.DTOs.Product;

namespace E_CommerceAPI.Application.Features.Queries.Product.SearchProducts
{
    public class SearchProductsQueryResponse
    {
        public IEnumerable<ProductDTO> Products { get; set; }
    }

}