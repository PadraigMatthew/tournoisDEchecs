using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tournoisDEchecs.Domain.Enums;

namespace tournoisDEchecs.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Pseudo { get; set; } = null!;
        public string Email { get; set; } = null!;
        public byte[] Password { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public genreStatus Status { get; set; }
        public int ELO { get; set; }
        public bool Role { get; set; }

        public List<Tournament> tournaments { get; set; }
        
    }
}
