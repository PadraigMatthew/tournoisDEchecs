using Be.Khunly.Security;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using tournoisDEchecs.API.DTO;
using tournoisDEchecs.BLL.Services;
using tournoisDEchecs.Domain.Entities;

namespace tournoisDEchecs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController(SecurityService _securityService, JwtManager _jwtManager) : ControllerBase
    {
        [HttpPost]
        public IActionResult LoginM([FromBody] LoginDTO dto)
        {
            try
            {
                User l = _securityService.Login(dto.Pseudo, dto.Password);
                string token = _jwtManager.CreateToken(l.Email, l.Id.ToString(), l.Email, l.Role ? "ADMIN": "MEMBER");
                return Ok(new { Token = token });
            }
            catch (ValidationException)
            {
                return BadRequest("Invalid Credentials");
            }
        }
    }
}

