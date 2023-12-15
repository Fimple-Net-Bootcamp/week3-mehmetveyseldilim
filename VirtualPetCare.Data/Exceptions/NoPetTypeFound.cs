using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualPetCare.Data.Exceptions
{
    public sealed class NoPetTypeFound : BadRequestException
    {
        public NoPetTypeFound() : base($"No pet type has been found")
        {
            
        }
    }
}