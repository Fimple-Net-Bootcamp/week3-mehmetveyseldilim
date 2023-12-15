using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VirtualPetCare.Data.Contracts;
using VirtualPetCare.Data.DTOs;

namespace VirtualPetCare.Data.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly IMapper _mapper;
        private readonly VirtualPetCareDbContext _context;


        public FoodRepository(IMapper mapper, VirtualPetCareDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public Task<bool> FeedThePet(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ReadFoodDTO> GetAllFoodsAsync()
        {
            throw new NotImplementedException();
        }
    }
}