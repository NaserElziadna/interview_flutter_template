using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBE.Application.DTOs.OrderDTO;
using PizzaBE.Application.Interfaces;
using PizzaBE.RestApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaBE.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Identity.Application," + JwtBearerDefaults.AuthenticationScheme)]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("all-admin")]
        [Authorize("worker")]
        public async Task<MyCustomApiResponse<List<OrderDTO>>> GetAll() {
            var res = await _orderService.GetAll();

            return new MyCustomApiResponse<List<OrderDTO>>(res);
        }

        [HttpGet]
        [Route("all")]
        public async Task<MyCustomApiResponse<List<OrderDTO>>> GetAllByUser()
        {
            var res = await _orderService.GetAllOrderByUser();

            return new MyCustomApiResponse<List<OrderDTO>>(res);
        }
    }
}
