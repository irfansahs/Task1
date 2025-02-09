using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task1.Application.Dtos;
using Task1.Application.Services;

namespace Task1.WebAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]

    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (loginDto == null || string.IsNullOrWhiteSpace(loginDto.UserName) || string.IsNullOrWhiteSpace(loginDto.Password))
                return BadRequest(new { Response = false, Token = "" });

            var token = await _loginService.LoginAsync(loginDto);

            if (string.IsNullOrEmpty(token))
                return Unauthorized(new { Response = false, Token = "" });

            return Ok(new { Response = true, Token = token });
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (registerDto == null || string.IsNullOrWhiteSpace(registerDto.Username) || string.IsNullOrWhiteSpace(registerDto.Password))
                return BadRequest(new { Response = false, Token = "" });

            var token = await _loginService.RegisterAsync(registerDto);

            if (string.IsNullOrEmpty(token))
                return BadRequest(new { Response = false, Token = "" });

            return Ok(new { Response = true, Token = token });
        }

    }
}