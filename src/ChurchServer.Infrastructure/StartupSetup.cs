using ChurchServer.Application.Common.Interfaces;
using ChurchServer.Core.Entities;
using ChurchServer.Core.Interfaces;
using ChurchServer.Infrastructure.Data;
using ChurchServer.Infrastructure.Identity;
using ChurchServer.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace ChurchServer.Infrastructure
{
    public static class StartupSetup
    {
        public static AppSettings GetAppSettings(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            var applicationSettings = configuration.GetSection("ApplicationSettings");
            services.Configure<AppSettings>(applicationSettings);
            return applicationSettings.Get<AppSettings>();
        }
        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                  .AddDbContext<ChurchDbContext>(options => options
                      .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<ChurchDbContext>();

            return services;
        }
        public static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services,
            AppSettings appSettings)
        {
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            return services;
        }
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
            => services
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<IRepository, EfRepository>()
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<IEmailSender, EmailSender>();


        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services
                  .AddSwaggerGen(c =>
                  {
                      c.SwaggerDoc(
                          "v1",
                          new OpenApiInfo
                          {
                              Title = "My Church API",
                              Version = "v1"
                          });
                      c.EnableAnnotations();
                  });
            return services;
        }
    }
}
