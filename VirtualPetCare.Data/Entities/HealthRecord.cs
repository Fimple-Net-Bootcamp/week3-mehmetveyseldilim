using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualPetCare.Data.Entities
{
    public class HealthRecord
    {
        [Key]
        public int Id {get; set;}

        [Required]
        [Column(TypeName = "varchar(24)")]
        [EnumDataType(typeof(HealthStatus))]
        public HealthStatus GeneralHealth { get; set; }


        public DateTime? LastVaccinationDate { get; set; }

        public double? Weight {get; set;}


        //. Navigation Properties

        [Required]
        [ForeignKey($"{nameof(PetId)}")]

        public int PetId {get; set;}

        public Pet? Pet {get; set;}

    }

    public enum HealthStatus
    {
        Excellent,
        Good,
        Fair,
        Poor
    }

}