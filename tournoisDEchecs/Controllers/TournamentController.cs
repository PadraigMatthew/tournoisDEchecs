using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using tournoisDEchecs.API.DTO.User;
using tournoisDEchecs.BLL.Services;

namespace tournoisDEchecs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController(TournamentService _tournamentService) : ControllerBase
    {
        [HttpPost]
        public IActionResult Ajouter([FromBody] AddTournoiDTO dto)
        {
            try
            {
                return Ok(_tournamentService.Add(dto.Lieu, dto.InscriptionEnDate, dto.MinP, dto.MaxP, dto.EloMin, dto.EloMax, dto.Statutes, dto.WomanOnly));
            }
            catch (Exception ex )
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("10")]
        public IActionResult Find10() { return Ok(_tournamentService.Find10()); }
        [HttpGet]
        public IActionResult FindAll() { return Ok(_tournamentService.FindAll()); }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id) 
        {
            try
            {
                _tournamentService.Delete(id);
                return Ok();
            }
            catch (KeyNotFoundException) 
            {
                return NotFound();
            }
            catch (ValidationException)
            {
                return BadRequest();
            }
        }

    }
}
