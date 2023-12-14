using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using VirtualPetCare.Data.Contracts;
using VirtualPetCare.Data.Entities;
using VirtualPetCare.Data.Entities.ConfigurationModels;

namespace VirtualPetCare.Data.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IAuthenticationRepository> _authenticationRepository;

        public RepositoryManager(VirtualPetCareDbContext context, IMapper mapper, UserManager<User> userManager,
        RoleManager<CustomIdentityRole> roleManager, IOptionsMonitor<JwtConfiguration> configuration )
        {
            _authenticationRepository = new Lazy<IAuthenticationRepository>(() => new AuthenticationRepository(mapper, userManager, configuration, roleManager));
        }

        public IAuthenticationRepository AuthenticationRepository => _authenticationRepository.Value;

    }
}