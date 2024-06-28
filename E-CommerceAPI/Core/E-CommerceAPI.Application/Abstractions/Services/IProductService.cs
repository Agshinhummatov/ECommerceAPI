using E_CommerceAPI.Application.DTOs.Product;


namespace E_CommerceAPI.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task<ProductListDTO> GetAllProductAsync(int page, int size);
        Task<ProductDTO> GetByIdAsync(string id);

        Task CreateProductAsync(ProductDTO productDto);

        Task RemoveProductAsync(string id);

        Task UpdateProductAsync(string id, ProductUpdateDTO productUpdateDTO);

        Task<IEnumerable<ProductDTO>> SearchProductsAsync(string searchTerm);
    }
}
