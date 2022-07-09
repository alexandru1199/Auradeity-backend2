using DataAccess;
using DataAccess.Entities;
using Interfaces.Commands;
using Interfaces.Queries.Services;
using Microsoft.EntityFrameworkCore;
using Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Commands
{
    public class AuthenticationCommand : IAuthenticationCommand
    {
        private readonly AuraDeityContext _auraDeityContext;
        private readonly IJwtQueryService _jwtQueryService;

        public AuthenticationCommand(
            AuraDeityContext auraDeityContext,
            IJwtQueryService jwtQueryService)
        {
            _auraDeityContext = auraDeityContext;
            _jwtQueryService = jwtQueryService;
        }

        public async Task<string> SignUpAsync(SignupModel signupModel)
        {
            try
            {
                var userRegistered = await _auraDeityContext.UserAuths
                    .AnyAsync(entity => entity.Email == entity.Email.Trim().ToLower());

                if (userRegistered)
                {
                    return "User already exists!";
                }

                ComputeHashPassword(signupModel.Password, out byte[] keyPassword, out byte[] hashPassword);

                var userAuth = new UserAuthEntity
                {
                    Email = signupModel.Email.Trim().ToLower(),
                    HashPassword = hashPassword,
                    KeyPassword = keyPassword,
                    CreatedOn = DateTime.Now,
                };

                _auraDeityContext.UserAuths.Add(userAuth);
                var isSavedSuccessfully = await _auraDeityContext.SaveChangesAsync() > 0;
                return isSavedSuccessfully ? _jwtQueryService.GetJwtToken(userAuth.Email, userAuth.Id) : string.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ComputeHashPassword(string password, out byte[] keyPassword, out byte[] hashPassword)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                keyPassword = hmac.Key;
                hashPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
