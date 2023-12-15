using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualPetCare.Data.DTOs;

namespace VirtualPetCare.Data.Contracts
{
    public interface IActivityRepository
    {
        Task<ReadActivityDTO> CreateActivityAsync(CreateActivityDTO createActivityDTO);

        Task<IEnumerator<ReadActivityDTO>> GetActivitiesForSpesificPetAsync(int petId);
    }
}