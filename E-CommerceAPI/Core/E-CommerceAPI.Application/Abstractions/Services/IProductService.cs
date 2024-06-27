using E_CommerceAPI.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
