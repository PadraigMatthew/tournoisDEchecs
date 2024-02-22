using System.ComponentModel.DataAnnotations;
using tournoisDEchecs.Domain.Enums;

namespace tournoisDEchecs.API.DTO.User
{
    public class RegisterDTO
    {
        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string Pseudo { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string Email { get; set; } = null!;

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public byte[] Password { get; set; } = null!;

        [Required]
        public genreStatus Status { get; set; }
    }
}