using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using VirtualPetCare.Data.DTOs;

namespace VirtualPetCare.Data.Contracts
{
    public interface IAuthenticationRepository
    {
            Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
            Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);

            Task<TokenDto> CreateToken(bool populateExp);

            Task<TokenDto> RefreshToken(TokenDto tokenDto);
    }
}