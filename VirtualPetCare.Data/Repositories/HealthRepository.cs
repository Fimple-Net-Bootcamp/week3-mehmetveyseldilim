using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VirtualPetCare.Data.Contracts;
using VirtualPetCare.Data.DTOs;

namespace VirtualPetCare.Data.Repositories
{
    public class HealthRepository : IHealthRepository
    {
        private readonly IMapper _mapper;

        private readonly VirtualPetCareDbContext _context;

        public HealthRepository(IMapper mapper, VirtualPetCareDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<ReadHealthRecord> GetHealthRecordForSpesificPetAsync(int petId)
        {
            throw new NotImplementedException();
        }

        public Task<ReadHealthRecord> UpdateHealthRecordForSpesificPetAsync(int petId)
        {
            throw new NotImplementedException();
        }
    }
}