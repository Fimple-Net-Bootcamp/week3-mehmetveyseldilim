using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualPetCare.Data.DTOs;

namespace VirtualPetCare.Data.Contracts
{
    public interface IPetRepository
    {
        public Task CreatePetAsync(CreatePetDTO createPetDTO);

        public Task<IEnumerable<ReadPetDTO>> GetAllPetsAsync();

        public Task<ReadPetDTO> GetPetByIdAsync(int petId);

        public Task<ReadPetDTO> UpdatePetAsync(UpdatePetDTO updatePetDTO);

        

    }
}