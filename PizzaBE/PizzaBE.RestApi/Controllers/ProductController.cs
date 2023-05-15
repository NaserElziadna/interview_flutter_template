using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBE.Application.DTOs.ProductDTO;
using PizzaBE.Application.Interfaces;
using PizzaBE.RestApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaBE.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<MyCustomApiResponse<List<ProductDTO>>> GetAll()
        {
            try
            {
                var result = await _productService.GetAllProductAsync();
                return new MyCustomApiResponse<List<ProductDTO>>(result);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task Add([FromBody]CreateProductDTO model)
        {
            try
            {
                await _productService.AddProductAsync(model);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }
}
