using AutoMapper;
using PizzaBE.Application.DTOs.ProductDTO;
using PizzaBE.Application.Interfaces;
using PizzaBE.Domain.Entities;
using PizzaBE.Domain.Interfaces.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBE.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddProductAsync(CreateProductDTO model)
        {
            var mapped = _mapper.Map<Product>(new ProductDTO
            {
                Name = model.Name,
                price = model.price
            });

            _unitOfWork.Products.Add(mapped);

            await _unitOfWork.SaveChangesAsync();
        }

        public Task DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductDTO>> GetAllProductAsync()
        {
            var all = await _unitOfWork.Products.GetAllAsync();
            var mapped = _mapper.Map<List<ProductDTO>>(all);

            return mapped;
        }

        public Task UpdateProductAsync(ProductDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
