using E_CommerceAPI.Application.Abstractions.Services;
using E_CommerceAPI.Application.DTOs;
using E_CommerceAPI.Application.DTOs.Product;
using E_CommerceAPI.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace E_CommerceAPI.Persistence.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductReadRepository _productReadRepository;

        public ProductService(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<ProductListDTO> GetAllProductAsync(int page, int size)
        {
            var totalProductCount = await _productReadRepository.GetAll(false).CountAsync();

            var products = await _productReadRepository.GetAll(false)
                .Skip(page * size)
                .Take(size)
                .Include(p => p.ProductImageFiles)
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Stock = p.Stock,
                    CreatedDate = p.CreatedDate,
                    UpdatedDate = p.UpdatedDate,
                    ProductImageFiles = p.ProductImageFiles.Select(img => new ProductImageFileDTO
                    {
                        Path = img.Path
                        // Map other properties if needed
                    }).ToList()
                }).ToListAsync();

            return new ProductListDTO
            {
                Products = products,
                TotalProductCount = totalProductCount
            };
        }

    }
}
