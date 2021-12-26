using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping.Api.Models;
using Shopping.Domain.Service;

namespace Shopping.Api.Controller
{
    [Route("api/order")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("account/{accountId}")]
        public async Task<IActionResult> GetOrdersByAccountId(long accountId)
        {
            try
            {
                var token = "";

                if (Request.Headers.ContainsKey("Authorization"))
                {
                    var jwt = (Request.Headers.FirstOrDefault(s => s.Key.Equals("Authorization"))).Value;

                    if (jwt.Count <= 0)
                    {
                        return StatusCode(400);
                    }

                    token = jwt[0].Replace("Bearer ", "");
                }

                return Ok(await _orderService.GetOrdersByAccountId(accountId, token));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("orderNum")]
        public async Task<IActionResult> GetOrdersByOrderNum([FromQuery] int orderNum)
        {
            try
            {
                var token = "";

                if (Request.Headers.ContainsKey("Authorization"))
                {
                    var jwt = (Request.Headers.FirstOrDefault(s => s.Key.Equals("Authorization"))).Value;

                    if (jwt.Count <= 0)
                    {
                        return StatusCode(400);
                    }

                    token = jwt[0].Replace("Bearer ", "");
                }

                return Ok(await _orderService.GetOrdersByOrderNum(orderNum, token));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("purchase")]
        public async Task<IActionResult> PurchaseOrder([FromBody] PurchaseOrderRequest request)
        {
            try
            {
                await _orderService.PurchaseOrder(request.AccountId);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}