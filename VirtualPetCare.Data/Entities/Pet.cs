using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualPetCare.Data.Entities
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Type { get; set; }
        [Required]
        public required string Name { get; set; }

        [Required]
        [ForeignKey($"{nameof(User)}")]
        public int UserId {get; set;}
        public User? User {get; set;}


        public HealthRecord? HealthRecord {get; set;}



        [Required]
        public int PetTypeId {get; set;}

        public PetType? PetType {get; set;}


    }


}