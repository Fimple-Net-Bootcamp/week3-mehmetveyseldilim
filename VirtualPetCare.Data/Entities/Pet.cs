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
        [ForeignKey($"{nameof(UserId)}")]
        public int UserId {get; set;}
        public User? User {get; set;}

        [Required]
        [Column(TypeName = "nvarchar(24)")]
        [EnumDataType(typeof(HealthStatus))]

        public HealthStatus HealthStatus{get; set;}


    }

    public enum HealthStatus 
    {
        Unknown,
        Good,
        Bad
    }
}