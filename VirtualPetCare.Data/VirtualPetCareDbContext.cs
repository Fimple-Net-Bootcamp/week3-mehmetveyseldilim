using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VirtualPetCare.Data.Entities;

namespace VirtualPetCare.Data
{
    
    public class VirtualPetCareDbContext : IdentityDbContext<User, CustomIdentityRole, int>
    {
        public const string SCHEMA_NAME = "VirtualPetCareSchema";

        public DbSet<Pet> Pets {get; set;}

        public DbSet<Activity> Activities {get; set;}

        public DbSet<Food> Foods {get; set;}

        public DbSet<PetType> PetTypes {get; set;}

        public DbSet<PetTypeActivity> PetTypeActivities {get; set;}

        public DbSet<PetTypeFood> PetTypeFoods {get; set;}

        public DbSet<HealthRecord> HealthRecords {get; set;}


        public VirtualPetCareDbContext(DbContextOptions<VirtualPetCareDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<PetTypeActivity>()
                .HasKey(pta => new { pta.ActivityId, pta.PetTypeId });

            modelBuilder.Entity<PetTypeFood>()
                .HasKey(pta => new { pta.FoodId, pta.PetTypeId });
            
            modelBuilder.HasDefaultSchema(SCHEMA_NAME);

            base.OnModelCreating(modelBuilder);
        }
    }
}