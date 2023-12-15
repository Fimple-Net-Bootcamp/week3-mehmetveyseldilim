using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualPetCare.Data.DTOs
{
    public class CreateActivityDTO
    {
        [Required]
        public required string ActivityName {get; set;}
        [Required]
        public ICollection<string> PetTypes {get; set;}

    }
}