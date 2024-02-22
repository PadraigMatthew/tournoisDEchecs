using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tournoisDEchecs.Domain.Entities;

namespace tournoisDEchecs.BLL.Interfaces
{
    public interface IUserRepository
    {
        User Add(User user);

        User? FindByEmail(string email);
        User? FindByPseudo(string pseudo);
    }
}
