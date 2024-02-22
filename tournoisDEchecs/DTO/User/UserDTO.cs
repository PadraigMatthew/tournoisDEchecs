using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using tournoisDEchecs.Domain.Enums;
using D = tournoisDEchecs.Domain.Entities;
namespace tournoisDEchecs.API.DTO.User
{
    public class UserDTO
    {
        public UserDTO(D.User user)
        {
            Id = user.Id;
            Pseudo = user.Pseudo;
            BirthDate = user.BirthDate;
            Status = user.Status;
            ELO = user.ELO;
        }
        public int Id { get; set; }
        public string Pseudo { get; set; }
        public DateTime BirthDate { get; set; }
        public genreStatus Status { get; set; }
        [Required]
        [Range(0, 3000)]
        public int ELO { get; set; }

    }
}
