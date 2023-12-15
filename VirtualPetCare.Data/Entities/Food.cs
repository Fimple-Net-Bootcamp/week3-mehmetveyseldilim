using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualPetCare.Data.Entities
{
    public class Food
    {
        [Key]
        public int Id {get; set;}
        [Required]
        public required string FoodName {get; set;}

    }
}