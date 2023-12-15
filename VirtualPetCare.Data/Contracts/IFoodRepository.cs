using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualPetCare.Data.DTOs;

namespace VirtualPetCare.Data.Contracts
{
    public interface IFoodRepository
    {
        Task<ReadFoodDTO> GetAllFoodsAsync();

        Task<bool> FeedThePet(int id); 
    }
}