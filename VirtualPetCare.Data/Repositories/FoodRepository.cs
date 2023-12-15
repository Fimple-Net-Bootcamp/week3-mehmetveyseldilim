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
    public class FoodRepository : IFoodRepository
    {
        private readonly IMapper _mapper;
        private readonly VirtualPetCareDbContext _context;


        public FoodRepository(IMapper mapper, VirtualPetCareDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public async Task<bool> FeedThePet(int id, int foodId)
        {
            var pet = await GetPetById(id);

            var food = await GetFoodById(foodId);

            var feed = await FeedThePet(pet, food);

            return feed;
        }

        public async Task<ReadFoodDTO> GetAllFoodsAsync()
        {
            var foods = await _context.Foods.ToListAsync();

            var mappedFoods = _mapper.Map<ReadFoodDTO>(foods);

            return mappedFoods;
        }

        private async Task<Pet> GetPetById(int id) 
        {
            var pet = await _context.Pets.Where(pet => pet.Id == id).FirstOrDefaultAsync();

            if(pet == null) 
            {
                throw new PetNotFound(id);
            }

            return pet;
        }

        private async Task<Food> GetFoodById(int id) 
        {
            var food = await _context.Foods.Where(food => food.Id == id).FirstOrDefaultAsync();

            if(food == null) 
            {
                throw new FoodNotFound(id);
            }

            return food;
        }



        private async Task<bool> FeedThePet(Pet pet, Food food) 
        {
            int petTypeId = pet.PetTypeId;

            var doesPetConsumeThisFood = await _context
                                        .PetTypeFoods.
                                        AnyAsync(petTypeFood => petTypeFood.PetTypeId == petTypeId);


            return doesPetConsumeThisFood;

        }
    }
}