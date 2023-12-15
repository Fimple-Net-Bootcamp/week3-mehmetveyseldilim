using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VirtualPetCare.Data.Entities
{
    [Keyless]
    public class PetTypeFood
    {
        [ForeignKey($"{nameof(FoodId)}")]
        public int FoodId {get; set;}

        [ForeignKey($"{nameof(PetTypeId)}")]
        public int PetTypeId {get; set;}
        public PetType? PetType {get; set;}

        public Food? Food {get; set;}
    }
}