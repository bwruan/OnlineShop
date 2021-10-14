using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentInfo.Domain.Services;

namespace PaymentInfo.Api.Controllers
{
    [Route("api/payment")]
    [ApiController]
    [Authorize]
    public class CardTypeController : ControllerBase
    {
        private readonly ICardTypeService _cardTypeService;

        public CardTypeController(ICardTypeService cardTypeService)
        {
            _cardTypeService = cardTypeService;
        }

        [HttpGet("cardType")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCardTypes()
        {
            try
            {
                return Ok(await _cardTypeService.GetCardTypes());                
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}