using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualPetCare.Data.Entities
{
    public class PetType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EnumDataType(typeof(PetTypeEnum))]
        [Column(TypeName = "nvarchar(24)")]
        
        public PetTypeEnum ThePetType {get; set;}

        public ICollection<Pet>? Pets {get; set;}
        
    }

    public enum PetTypeEnum
    {
        Dog,
        Cat,
        Fish,
        Hamster
    }


}