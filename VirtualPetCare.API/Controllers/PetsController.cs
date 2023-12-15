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
    [Route("api/pets")]
    public class PetsController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;

        public PetsController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }


        [HttpPost]
        public async Task<IActionResult>  CreatePet(CreatePetDTO createPetDTO)
        {
            await _repositoryManager.PetRepository.CreatePetAsync(createPetDTO);

            return Ok();
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<ReadPetDTO>>> GetAllPets()
        {
            var pets = await _repositoryManager.PetRepository.GetAllPetsAsync();

            return Ok(pets);
        }

        [HttpGet("{petId}")]
        public async Task<ActionResult<ReadPetDTO>> GetPetById(int petId) 
        {
            var pet = await _repositoryManager.PetRepository.GetPetByIdAsync(petId);

            return Ok(pet);
        }

        
        
        
    }
}