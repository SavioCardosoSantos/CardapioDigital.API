using CardapioDigital.Application.Interfaces;
using CardapioDigital.Application.Mappings;
using CardapioDigital.Application.Services;
using CardapioDigital.Domain.Interfaces;
using CardapioDigital.Infra.Data.Context;
using CardapioDigital.Infra.Data.Repositiories;
using CardapioDigital.Infra.Data.Repositories;
using CardapioDigital.Infra.Ioc.Mappings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CardapioDigital.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAutoMapper(typeof(EntitiesToDTOMappingProfile));
            services.AddAutoMapper(typeof(DTOToModelsMappingProfile));

            // Repositories
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IRestauranteRepository, RestauranteRepository>();

            // Services
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IRestauranteService, RestauranteService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
