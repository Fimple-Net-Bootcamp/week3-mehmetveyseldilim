using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCare.Data.Contracts;
using VirtualPetCare.Data.DTOs;

namespace VirtualPetCare.API.Controllers
{
    [ApiController]
    [Route("api/foods")]
    public class FoodsController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;

        public FoodsController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadFoodDTO>>> GetAllFoods()
        {
            var readFoodDTOs = await _repositoryManager.FoodRepository.GetAllFoodsAsync();

            return Ok(readFoodDTOs);
        }

        [HttpPost("{petId}/{foodId}")]
        public async Task<IActionResult> FeedThePet(int petId, int foodId) 
        {
            var boole = await _repositoryManager.FoodRepository.FeedThePet(petId, foodId);

            if(!boole) return BadRequest();

            return Ok(boole);
        }
    }
}