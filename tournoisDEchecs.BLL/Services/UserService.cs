using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using tournoisDEchecs.BLL.Interfaces;
using tournoisDEchecs.Domain.Entities;
using tournoisDEchecs.Domain.Enums;

namespace tournoisDEchecs.BLL.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public User Register(string Pseudo, string Email, DateTime birthDate, byte[] password, genreStatus status)
        {
            //verification du ELO
            /*if(ELO < 0 || ELO > 3000)
            {
                throw new ValidationException();
            }*/

           // verifier mail unique 
            if(_userRepository.FindByEmail(Email) != null)
            {
              throw new ValidationException();
            }
            
            // verifier le pseudo unique
            if(_userRepository.FindByPseudo(Pseudo) != null)
            {
                throw new ValidationException();
            }
          
            //les mots de passe devront être hachés dans la db, l'ajout d'un sel est conseillé.
            byte[] hash = _passwordHasher.Hash(Pseudo + password + Email);
            //ajouter un membre
            return _userRepository.Add(new User
            {
                Pseudo = Pseudo,
                Email = Email,
                Password = hash,
                BirthDate = birthDate,
                Status = status,
                ELO = 1200,
                //Role = Role
            });
        }
    }
}
