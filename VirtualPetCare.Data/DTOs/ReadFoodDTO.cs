using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualPetCare.Data.DTOs
{
    public class ReadFoodDTO
    {
        public int Id {get; set;}
        public required string FoodName {get; set;}
    }
}