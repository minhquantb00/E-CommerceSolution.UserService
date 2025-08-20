using AutoMapper;
using E_Commerce.Core.DTO;
using E_Commerce.Core.Entities;
using E_Commerce.Core.Mappers;
using E_Commerce.Core.RepositoryContracts;
using E_Commerce.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
           ApplicationUser? user =  await _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
            if(user == null)
            {
                return null;
            }
            return ApplicationUserMapping.ToResponseSuccess(user);
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
            ApplicationUser? user = new ApplicationUser
            {
                PersonName = registerRequest.PersonName,
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                Gender = registerRequest.Gender.ToString()
            };

            ApplicationUser? userRegister = await _userRepository.AddUser(user);

            if ((userRegister == null))
            {
                return null;
            }

            return ApplicationUserMapping.ToResponseSuccess(userRegister);
        }
    }
}
