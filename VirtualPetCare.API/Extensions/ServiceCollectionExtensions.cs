
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VirtualPetCare.Data;
using VirtualPetCare.Data.Contracts;
using VirtualPetCare.Data.Entities;
using VirtualPetCare.Data.Entities.ConfigurationModels;
using VirtualPetCare.Data.Repositories;

namespace VirtualPetCare.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPostgresDbContext(this IServiceCollection services, IConfiguration configuration) 
        {
            string connectionString = configuration.GetConnectionString("Postgres")!;

            if(string.IsNullOrEmpty(connectionString)) 
            {
                Console.WriteLine("Connection string is null or empty");
                return;
            }

            services.AddDbContext<VirtualPetCareDbContext>(options => 
            {
                options.UseNpgsql(connectionString, 
                b => b.MigrationsAssembly("VirtualPetCare.API")
                .MigrationsHistoryTable("__EFMigrationsHistory", schema: VirtualPetCareDbContext.SCHEMA_NAME));

            });
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services) 
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        }

        public static void AddAutoMapperService(this IServiceCollection services) 
        {
            // services.AddAutoMapper(typeof(Program));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, CustomIdentityRole>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 10;
                o.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<VirtualPetCareDbContext>()
            .AddDefaultTokenProviders();
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfiguration = new JwtConfiguration();

            configuration.Bind(jwtConfiguration.Section, jwtConfiguration);

            var secretKey = Environment.GetEnvironmentVariable("SECRETTWO");

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfiguration.ValidIssuer,
                    ValidAudience = jwtConfiguration.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
        }

        public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration) 
        {
            services.Configure<JwtConfiguration>
                (configuration.GetSection("JwtSettings")).AddOptions<JwtConfiguration>().ValidateDataAnnotations();
        }
    

    }
}