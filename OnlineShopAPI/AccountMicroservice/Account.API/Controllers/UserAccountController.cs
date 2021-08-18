using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.API.Models;
using Account.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Account.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;
        private readonly IConfiguration _configuration;

        public UserAccountController(IUserAccountService userAccountService, IConfiguration configuration)
        {
            _userAccountService = userAccountService;
            _configuration = configuration;
        }

        [HttpPost("addAccount")]
        [AllowAnonymous]
        public async Task<IActionResult> AddAccount([FromBody] AddAccountRequest request)
        {
            try
            {
                await _userAccountService.AddAccount(request.Name, request.Email, request.Password);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetAccountById(long accountId)
        {
            try
            {
                var account = await _userAccountService.GetAccountById(accountId);

                return Ok(account);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAccountByEmail([FromQuery] string email)
        {
            try
            {
                var account = await _userAccountService.GetAccountByEmail(email);

                return Ok(account);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("updateAccount")]
        public async Task<IActionResult> UpdateAccount([FromBody] UpdateAccountRequest request)
        {
            try
            {

                await _userAccountService.UpdateAccount(request.AccountId, request.NewName, request.NewEmail, request.NewPassword);

                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn([FromBody] LoginRequest request)
        {
            try
            {
                var accountId = await _userAccountService.LogIn(request.Email, request.Password);

                var token = GenerateJSONWebToken();

                return Ok(new { token, accountId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch]
        [Route("logout/{accountId}")]
        public async Task<IActionResult> LogOut(long accountId)
        {
            try
            {
                await _userAccountService.LogOut(accountId);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration.GetSection("Jwt:Issuer").Value,
              _configuration.GetSection("Jwt:Issuer").Value,
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}