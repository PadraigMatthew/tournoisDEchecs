using Microsoft.AspNetCore.Mvc;
using tournoisDEchecs.API.DTO.User;
using tournoisDEchecs.BLL.Services;
using tournoisDEchecs.Domain.Entities;

namespace tournoisDEchecs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(UserService _userService) : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] RegisterDTO dto)
        {
            User user = _userService
                .Register(
                    dto.Pseudo,
                    dto.Email,
                    dto.BirthDate,
                    dto.Password,
                    dto.Status
            );

            // retourner un résultat
            return Created("", new UserDTO(user)); // 201
            // return Ok() 200
        }
    }
}
