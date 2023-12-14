using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCare.API.ActionFilters;
using VirtualPetCare.Data.Contracts;
using VirtualPetCare.Data.DTOs;

namespace VirtualPetCare.API.Controllers
{
    [ApiController]
    [Route("api/kullanicilar")]
    public class AuthenticationController : ControllerBase
    {

        private readonly IRepositoryManager _repository;

        public AuthenticationController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetUserById(int id) 
        {
            var user = await _repository.AuthenticationRepository.GetUserByIdAsync(id);

            return Ok(user);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            var result = await _repository.AuthenticationRepository.RegisterUser(userForRegistration);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _repository.AuthenticationRepository.ValidateUser(user))
                return Unauthorized();

            var tokenDto = await _repository.AuthenticationRepository.CreateToken(populateExp: true);

            return Ok(tokenDto);
        }
        
    }
}