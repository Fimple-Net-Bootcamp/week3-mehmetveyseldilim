using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualPetCare.Data.DTOs;

namespace VirtualPetCare.Data.Contracts
{
    public interface IHealthRepository
    {
        Task<ReadHealthRecord> GetHealthRecordForSpesificPetAsync(int petId);

        Task<ReadHealthRecord> UpdateHealthRecordForSpesificPetAsync(int petId);
    }
}