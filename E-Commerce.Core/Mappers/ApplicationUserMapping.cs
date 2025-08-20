using E_Commerce.Core.DTO;
using E_Commerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Mappers
{
    public static class ApplicationUserMapping
    {
        public static AuthenticationResponse ToResponseSuccess(this ApplicationUser applicationUser)
        {
            return new AuthenticationResponse
            {
                Email = applicationUser.Email,
                Gender = applicationUser.Gender,
                PersonName = applicationUser.PersonName,
                UserId = applicationUser.UserId,
                Success = true,
                Token = "token"
            };
        }
    }
}
