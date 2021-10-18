using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentInfo.Api.Models;
using PaymentInfo.Domain.Services;

namespace PaymentInfo.Api.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("addPayment")]
        public async Task<IActionResult> AddPayment([FromBody] PaymentRequest request)
        {
            try
            {
                await _paymentService.AddPayment(request.NameOnCard, request.CardNumber, request.SecurityCode, request.ExpDate, request.BillingName, request.BillingUnit,
                    request.BillingCity, request.BillingState, request.BillingZipcode, request.CardType, request.AccountId);

                return StatusCode(201);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("getPayment/{paymentId}")]
        public async Task<IActionResult> GetPaymentByPaymentId(long paymentId)
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

                var payment = await _paymentService.GetPaymentByPaymentId(paymentId, token);

                return Ok(payment);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("paymentList/{accountId}")]
        public async Task<IActionResult> GetPaymentsByAccountId(long accountId)
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

                var paymentList = await _paymentService.GetPaymentsByAccountId(accountId, token);

                return Ok(paymentList);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("updatePayment")]
        public async Task<IActionResult> UpdatePayment([FromBody] UpdatePaymentRequest request)
        {
            try
            {
                await _paymentService.UpdatePayment(request.PaymentId, request.NewNameOnCard, request.NewCardNumber, request.NewSecurityCode, request.NewExpDate, request.NewBillingName,
                    request.NewBillingUnit, request.NewBillingCity, request.NewBillingState, request.NewBillingZipcode, request.NewCardType);

                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("deletePayment/{paymentId}")]
        public async Task<IActionResult> DeletePayment(long paymentId)
        {
            try
            {
                await _paymentService.DeletePayment(paymentId);

                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}