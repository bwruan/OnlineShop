using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    }
}