using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualPetCare.Data.DTOs
{
    public class ReadActivityDTO
    {
        public int Id {get; set;}
        public required string ActivityName {get; set;}
    }
}