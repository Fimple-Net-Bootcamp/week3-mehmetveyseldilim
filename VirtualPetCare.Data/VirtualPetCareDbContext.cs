using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VirtualPetCare.Data.Entities;

namespace VirtualPetCare.Data
{
    
    public class VirtualPetCareDbContext : IdentityDbContext<User, CustomIdentityRole, int>
    {
        public const string SCHEMA_NAME = "Virtual";

        public DbSet<Pet> Pets {get; set;}

        public DbSet<Activity> Activities {get; set;}

        public DbSet<Food> Foods {get; set;}

        public DbSet<Type> Types {get; set;}


        public VirtualPetCareDbContext(DbContextOptions<VirtualPetCareDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            
            modelBuilder.HasDefaultSchema(SCHEMA_NAME);

            base.OnModelCreating(modelBuilder);
        }
    }
}