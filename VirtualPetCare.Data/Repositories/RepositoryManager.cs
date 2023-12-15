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

        private readonly Lazy<IActivityRepository> _activityRepository;

        private readonly Lazy<IFoodRepository> _foodRepository;

        private readonly Lazy<IHealthRepository> _healthRepository;

        private readonly Lazy<IPetRepository> _petRepository;

        private readonly Lazy<ITypeRepository> _typeRepository;



        public RepositoryManager(VirtualPetCareDbContext context, IMapper mapper, UserManager<User> userManager,
        RoleManager<CustomIdentityRole> roleManager, IOptionsMonitor<JwtConfiguration> configuration )
        {
            _authenticationRepository = new Lazy<IAuthenticationRepository>(() => new AuthenticationRepository(mapper, userManager, configuration, roleManager));
             _typeRepository = new Lazy<ITypeRepository>(() => new TypeRepository(mapper, context));
             _foodRepository = new Lazy<IFoodRepository>(() => new FoodRepository(mapper, context));
             _healthRepository = new Lazy<IHealthRepository>(() => new HealthRepository(mapper, context));
             _petRepository = new Lazy<IPetRepository>(() => new PetRepository(mapper, context));
            _activityRepository = new Lazy<IActivityRepository>(() => new ActivityRepository(mapper, context, TypeRepository));


        }

        public IAuthenticationRepository AuthenticationRepository => _authenticationRepository.Value;

        public IActivityRepository ActivityRepository => _activityRepository.Value;

        public IFoodRepository FoodRepository => _foodRepository.Value;

        public IHealthRepository HealthRepository => _healthRepository.Value;

        public IPetRepository PetRepository => _petRepository.Value;

        public ITypeRepository TypeRepository => _typeRepository.Value;
    }
}