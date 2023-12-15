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
        public IActionResult CreateActivity(CreateActivityDTO createActivityDTO) 
        {
            return Ok();
        }
    }
}