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
    [Route("api/activities")]
    public class ActivitiesController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;

        public ActivitiesController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        [HttpPost]
        public async Task<ActionResult<ReadActivityDTO>> CreateActivity(CreateActivityDTO createActivityDTO) 
        {
            var addedAcivityReadDTO = await _repositoryManager.ActivityRepository.CreateActivityAsync(createActivityDTO);

            return Ok(addedAcivityReadDTO);
        }

        [HttpGet("{petId}")]
        public async Task<ActionResult<IEnumerable<ReadActivityDTO>>> GetActivitiesForPet(int petId) 
        {
            var readActivityDTOList = await _repositoryManager.ActivityRepository.GetActivitiesForSpesificPetAsync(petId);

            return Ok(readActivityDTOList);
        }
    }
}