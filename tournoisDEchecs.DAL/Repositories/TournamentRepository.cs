using Be.KhunLy.EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tournoisDEchecs.BLL.Interfaces;
using tournoisDEchecs.Domain.Entities;

namespace tournoisDEchecs.DAL.Repositories
{
    public class TournamentRepository : BaseRepository<Tournament>, ITournamentRepository
    {

        public TournamentRepository(tournoisDEchecsContext context) : base(context) { }

        //afficher tous les tournois non clotures
        public List<Tournament> FindAll() {  return _table.ToList(); }

        //afficher les 10 derniers tournois non clotures par ordre decroissant sur la date de mise a jour
        public List<Tournament> Find10()
        {
            return _table
                .OrderByDescending(t => t.updateDate)
                .Take(10)
                .Where(t => t.LastDate >  DateTime.Now)
                .Select(t=> new Tournament { Id = t.Id, lieu = t.lieu
                , /*nbPlayers = ,*/ minPlayer = t.minPlayer
                , maxPlayer = t.maxPlayer, Categorie = t.Categorie
                , minElo = t.minElo, maxElo = t.maxElo, Status = t.Status
                , LastDate = t.LastDate, rondeCourante = t.rondeCourante })
                .ToList();
        }

        //afficher les details d'un tournoi (tout le monde)
        
        //se connecter (tout le monde)
        
        //s'inscrire a un tournoi (tous les utilisateurs connectes)

    }
}
