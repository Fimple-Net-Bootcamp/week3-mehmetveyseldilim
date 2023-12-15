using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCare.Data.Contracts;

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

        
        
    }
}