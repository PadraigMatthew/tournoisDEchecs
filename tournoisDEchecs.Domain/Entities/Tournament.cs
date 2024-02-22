using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tournoisDEchecs.Domain.Enums;

namespace tournoisDEchecs.Domain.Entities
{
    public class Tournament
    {
        public int Id { get; set; }
        public string lieu { get; set; } = null!;
        public int minPlayer { get; set; }
        public int maxPlayer { get; set; }
        public int minElo { get; set; }
        public int maxElo { get; set; }
        public categoriesStatus Categorie { get; set; }
        public statutsStatus Status { get; set; }
        public int rondeCourante { get; set; }
        public bool womenOnly { get; set; }
        public DateTime LastDate { get; set; }
        public DateTime createDate { get; set; }
        public DateTime updateDate { get; set; }

        public List<User> Users { get; set; }

    }
}
