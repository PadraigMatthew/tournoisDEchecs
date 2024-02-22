using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tournoisDEchecs.BLL.Interfaces;
using tournoisDEchecs.Domain.Entities;
using tournoisDEchecs.Domain.Enums;

namespace tournoisDEchecs.BLL.Services
{
    public class TournamentService(ITournamentRepository _tournamentRepository)
    {
        public void Delete(int id)
        {
            Tournament? tournament = _tournamentRepository.Find(id);
            if (tournament is null)
            {
                throw new KeyNotFoundException();
            }
            if (tournament.Status != statutsStatus.enAttenteDeJoueurs || tournament.LastDate < DateTime.Now)
            {
                throw new ValidationException();
            }
            _tournamentRepository.Remove(tournament);
        }

        public Tournament Add(string lieu, DateTime LastDate,
            int minPlayer, int maxPlayer, int minElo, int maxElo, categoriesStatus categorie, bool womenOnly)
        {

            if(minPlayer > maxPlayer)
            {
                throw new ValidationException("Le nombre de joueur ...");
            }

            if (minElo > maxElo)
            {
                throw new ValidationException("Le nombre de joueur ...");
            }

            if (LastDate < DateTime.Now.AddDays(minPlayer))
            {
                throw new ValidationException("La date ...");
            }
            return _tournamentRepository.Add(new Tournament
            {
                
                lieu = lieu,
                minPlayer = minPlayer,
                maxPlayer = maxPlayer,
                minElo = minElo,
                maxElo = maxElo,
                Categorie = categorie,
                rondeCourante = 0,
                womenOnly = womenOnly,
                Status = statutsStatus.enAttenteDeJoueurs,
                LastDate = LastDate,
                createDate = DateTime.Now,
                updateDate = DateTime.Now,
            });
        }

        public List<Tournament> Find10()
        {
            return _tournamentRepository.Find10();
        }

        public List<Tournament> FindAll()
        {  
            return _tournamentRepository.FindAll();
        }
    }
}
