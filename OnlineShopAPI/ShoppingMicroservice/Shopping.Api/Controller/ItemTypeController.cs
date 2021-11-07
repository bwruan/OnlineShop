using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping.Domain.Service;

namespace Shopping.Api.Controller
{
    [Route("api/itemType")]
    [ApiController]
    [Authorize]
    public class ItemTypeController : ControllerBase
    {
        private readonly IItemTypeService _itemTypeService;

        public ItemTypeController(IItemTypeService itemTypeService)
        {
            _itemTypeService = itemTypeService;
        }

        [HttpGet("itemType")]
        [AllowAnonymous]
        public async Task<IActionResult> GetItemType()
        {
            try
            {
                return Ok(await _itemTypeService.GetItemType());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}