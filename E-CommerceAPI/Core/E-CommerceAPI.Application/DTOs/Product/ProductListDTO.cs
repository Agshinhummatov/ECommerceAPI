using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAPI.Application.DTOs.Product
{
    public class ProductListDTO
    {
        public ICollection<ProductDTO> Products { get; set; }
        public int TotalProductCount { get; set; }
    }

}
