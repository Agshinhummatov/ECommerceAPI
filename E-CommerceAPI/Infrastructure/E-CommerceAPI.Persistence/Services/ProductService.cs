using E_CommerceAPI.Application.Abstractions.Services;
using E_CommerceAPI.Application.DTOs;
using E_CommerceAPI.Application.DTOs.Product;
using E_CommerceAPI.Application.Repositories;
using E_CommerceAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace E_CommerceAPI.Persistence.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;
        public ProductService(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
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
                    Id = p.Id.ToString(),
                    Name = p.Name,
                    Price = p.Price,
                    Stock = p.Stock,
                    CreatedDate = p.CreatedDate,
                    UpdatedDate = p.UpdatedDate,
                    ProductImageFiles = p.ProductImageFiles.Select(img => new ProductImageFileDTO
                    {
                        Path = img.Path
                        
                    }).ToList()
                }).ToListAsync();

            return new ProductListDTO
            {
                Products = products,
                TotalProductCount = totalProductCount
            };
        }


        public async Task<ProductDTO> GetByIdAsync(string id)
        {
            

            var product = await _productReadRepository.GetByIdAsync(id, false);

            if (product == null)
            {
                return null;
            }

            return new ProductDTO
            {
                Id = product.Id.ToString(),
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                CreatedDate = product.CreatedDate,
                UpdatedDate = product.UpdatedDate,
                ProductImageFiles = product.ProductImageFiles?.Select(img => new ProductImageFileDTO
                {

                }).ToList()
            };
        }


        public async Task CreateProductAsync(ProductDTO productDto)
        {
            if (productDto == null)
            {
                throw new ArgumentNullException(nameof(productDto), "Product data cannot be null");
            }

            await _productWriteRepository.AddAsync(new()
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Stock = productDto.Stock
            });

            await _productWriteRepository.SaveAsync();
        }



        public async Task RemoveProductAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Product ID cannot be null or empty", nameof(id));
            }

            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
        }


        public async Task UpdateProductAsync(string id, ProductUpdateDTO productUpdateDTO)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Product ID cannot be null or empty", nameof(id));
            }

            var product = await _productReadRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            product.Name = productUpdateDTO.Name;
            product.Price = productUpdateDTO.Price;
            product.Stock = productUpdateDTO.Stock;

            await _productWriteRepository.SaveAsync();
        }
    }


}








