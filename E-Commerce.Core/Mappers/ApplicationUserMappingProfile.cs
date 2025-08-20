using AutoMapper;
using E_Commerce.Core.DTO;
using E_Commerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Mappers
{
    public class ApplicationUserMappingProfile : Profile
    {
        public ApplicationUserMappingProfile()
        {
            CreateMap<ApplicationUser, AuthenticationResponse>()
                .ForMember(destination => destination.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(destination => destination.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(destination => destination.PersonName, opt => opt.MapFrom(src => src.PersonName))
                .ForMember(destination => destination.Gender , opt => opt.MapFrom(src => src.Gender))
                .ForMember(destination => destination.Success, opt => opt.Ignore())
                .ForMember(destination => destination.Token, opt => opt.Ignore())
                ;
        }
    }
}
