using System.ComponentModel.DataAnnotations;
using tournoisDEchecs.Domain.Enums;

namespace tournoisDEchecs.API.DTO.User
{
    public class AddTournoiDTO
    {

        [Required]
        public string Lieu { get; set; } = null!;

        [Range(2, 32)]
        public int MinP { get; set; }

        [Range(2, 32)]
        public int MaxP { get; set; }

        [Range(0,3000)]
        public int EloMin { get; set; }

        [Range(0, 3000)]
        public int EloMax { get; set; }

        [Required]
        public  categoriesStatus Statutes { get; set; }

        [Required]
        public DateTime InscriptionEnDate { get; set; }

        [Required]
        public bool WomanOnly { get; set; }
    }
}
