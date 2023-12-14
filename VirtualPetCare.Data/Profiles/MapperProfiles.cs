using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VirtualPetCare.Data.DTOs;
using VirtualPetCare.Data.Entities;

namespace VirtualPetCare.Data.Profiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            //. source -> destination
            CreateMap<UserForRegistrationDto, User>();

        }
    }
}