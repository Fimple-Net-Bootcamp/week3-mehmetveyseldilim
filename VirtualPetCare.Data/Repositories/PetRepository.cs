using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VirtualPetCare.Data.Contracts;
using VirtualPetCare.Data.DTOs;
using VirtualPetCare.Data.Entities;
using VirtualPetCare.Data.Exceptions;

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


        public async Task CreatePetAsync(CreatePetDTO createPetDTO)
        {
            var pet = _mapper.Map<Pet>(createPetDTO);

            _context.Pets.Add(pet);

            await _context.SaveChangesAsync();


        }

        public async Task<IEnumerable<ReadPetDTO>> GetAllPetsAsync()
        {
            var pets = await _context.Pets.ToListAsync();

            var mappedPets = _mapper.Map<IEnumerable<ReadPetDTO>>(pets);

            return mappedPets;
        }

        public async Task<ReadPetDTO> GetPetDTOByIdAsync(int petId)
        {
            var pet = await GetPetByIdAsync(petId);

            var mappedPet = _mapper.Map<ReadPetDTO>(pet);

            return mappedPet;
        }

        public Task<ReadPetDTO> UpdatePetAsync(UpdatePetDTO updatePetDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<Pet> GetPetByIdAsync(int petId) 
        {
            var pet = await _context.Pets.Where(pet => pet.Id == petId).FirstOrDefaultAsync();

            if (pet == null) 
            {
                throw new PetNotFound(petId);
            }

            return pet;
        }
    }
}