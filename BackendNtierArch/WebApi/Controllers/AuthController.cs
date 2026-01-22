using Business.Services.Abstracts;
using Entities.DTOs.AuthDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthSercive _service;

        public AuthController(IAuthSercive service)
        {
            _service = service;
        }

        [HttpPost]

        public async Task<IActionResult> Regiter(RegisterDto register)
        {
            var result = await _service.Register(register);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }



        [HttpPost]

        public async Task<IActionResult> Login(LoginDto login)
        {
            var result = await _service.Login(login);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }


        //[ApiExplorerSettings(IgnoreApi = true)]
        //[Authorize(Roles = "SuperAdmin")]
        [HttpPost("add-admin")]
        public async Task<IActionResult> AddAdmin(RegisterDto register)
        {
            var admin = await _service.AddAdmin(register);
            if (!admin.Success)
            {
                return BadRequest(admin.Message);
            }
            return Ok();
        }


    }
}
