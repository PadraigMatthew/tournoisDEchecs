using System.ComponentModel.DataAnnotations;

namespace tournoisDEchecs.API.DTO.User
{
    public class UpdateUserDTO
    {
        [Required]
        public string Pseudo { get; set; } = null!;
        [Required]
        public byte[] Password { get; set; } = null!;
    }
}
