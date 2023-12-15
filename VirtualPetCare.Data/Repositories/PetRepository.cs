using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VirtualPetCare.Data.Contracts;
using VirtualPetCare.Data.DTOs;

namespace VirtualPetCare.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly IMapper _mapper;

        private readonly VirtualPetCareDbContext _context;

        public PetRepository(IMapper mapper, VirtualPetCareDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public Task CreatePetAsync(CreatePetDTO createPetDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReadPetDTO>> GetAllPetsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ReadPetDTO> GetPetByIdAsync(int petId)
        {
            throw new NotImplementedException();
        }

        public Task<ReadPetDTO> UpdatePetAsync(UpdatePetDTO updatePetDTO)
        {
            throw new NotImplementedException();
        }
    }
}