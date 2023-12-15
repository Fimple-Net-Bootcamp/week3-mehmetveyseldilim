using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VirtualPetCare.Data.Entities
{
    [Keyless]
    public class PetTypeActivity
    {
        [ForeignKey($"{nameof(ActivityId)}")]
        public int ActivityId {get; set;}

        [ForeignKey($"{nameof(PetTypeId)}")]
        public int PetTypeId {get; set;}

        public PetType? PetType {get; set;}

        public Activity? Activity {get; set;}
    }
}