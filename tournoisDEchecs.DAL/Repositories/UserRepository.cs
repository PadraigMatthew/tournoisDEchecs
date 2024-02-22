using Be.KhunLy.EF.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tournoisDEchecs.BLL.Interfaces;
using tournoisDEchecs.Domain.Entities;

namespace tournoisDEchecs.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(tournoisDEchecsContext context) : base(context)
        {
        }


        public User? FindByEmail(string email)
        {
            return _table.FirstOrDefault(x => x.Email == email);
        }
        public User? FindByPseudo(string pseudo)
        {
            return _table.FirstOrDefault(x => x.Pseudo == pseudo);
        }

    }
}
