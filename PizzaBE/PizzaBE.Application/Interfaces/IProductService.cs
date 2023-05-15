using PizzaBE.Application.DTOs.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Application.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllProductAsync();
        Task AddProductAsync(CreateProductDTO model);
        Task UpdateProductAsync(ProductDTO model);
        Task DeleteProductAsync(int id);
    }
}
