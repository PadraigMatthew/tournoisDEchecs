using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tournoisDEchecs.Domain.Entities;

namespace tournoisDEchecs.BLL.Interfaces
{
    public interface ITournamentRepository
    {
        Tournament Add(Tournament tournament);
        void Remove(Tournament tournament);
        void Update(Tournament tournament);
        Tournament? Find(params object[] id);
        List<Tournament> Find10();
        List<Tournament> FindAll();
    }
}
