using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tournoisDEchecs.BLL.Interfaces;
using tournoisDEchecs.Domain.Entities;

namespace tournoisDEchecs.BLL.Services
{
    public class SecurityService(IUserRepository _userRepository, IPasswordHasher _passwordHasher)
    {
        public User Login(string email, string password)
        {
            User? l = _userRepository.FindByEmail(email);
            if (l == null)
            {
                throw new ValidationException("Aucun user avec cet email");
            }
            if (!_passwordHasher.Hash(l.Email + password).SequenceEqual(l.Password))
            {
                throw new ValidationException("pwd non valide");
            }
            return l;
        }
    }
}
