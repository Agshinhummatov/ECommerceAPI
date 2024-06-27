using E_CommerceAPI.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAPI.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductsQueryResponse
    {

        public ICollection<ProductDTO> Products { get; set; }
        public int TotalProductCount { get; set; }
    }
}
