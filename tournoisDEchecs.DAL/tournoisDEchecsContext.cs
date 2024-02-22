using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tournoisDEchecs.Domain.Entities;

namespace tournoisDEchecs.DAL
{
    public class tournoisDEchecsContext : DbContext
    {
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<User> Users { get; set; }

        public tournoisDEchecsContext(DbContextOptions options) : base(options) { }
    }
}
