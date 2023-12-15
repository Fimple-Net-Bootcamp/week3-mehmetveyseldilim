using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VirtualPetCare.Data.Contracts;
using VirtualPetCare.Data.DTOs;

namespace VirtualPetCare.Data.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly IMapper _mapper;

        private readonly VirtualPetCareDbContext _context;

        public ActivityRepository(IMapper mapper, VirtualPetCareDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<ReadActivityDTO> CreateActivityAsync(CreateActivityDTO createActivityDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerator<ReadActivityDTO>> GetActivitiesForSpesificPetAsync(int petId)
        {
            throw new NotImplementedException();
        }
    }
}