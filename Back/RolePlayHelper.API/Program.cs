using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RolePlayHelper.API.Middlewares;
using RolePlayHelper.API.Services;
using RolePlayHelper.BLL.Services;
using RolePlayHelper.DAL.Database;
using RolePlayHelper.DAL.Repositories;
using System.Text;
using RolePlayHelper.API.CustomAuthorize.IsGM;
using Microsoft.AspNetCore.Authorization;
using RolePlayHelper.BLL;

namespace RolePlayHelper.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization: Entrer : 'Bearer <token>'"
                });

                // Permet de rajouter le "cadena" sur les routes (ce qui fait que l'authorization est ajouté au header)
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }

                });

                // - Plus d'infos : 
                // https://github.com/domaindrivendev/Swashbuckle.AspNetCore?tab=readme-ov-file#add-security-definitions-and-requirements
            });

            #region Repositories
            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddScoped<StatModifierRepository>();
            builder.Services.AddScoped<RaceRepository>();
            builder.Services.AddScoped<RaceTraitRepository>();
            builder.Services.AddScoped<LanguageRepository>();
            builder.Services.AddScoped<CharacterRepository>();
            builder.Services.AddScoped<CharClassRepository>();
            builder.Services.AddScoped<CampaignRepository>();
            
            #endregion

            #region Services
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<AuthService>();
            builder.Services.AddScoped<RaceService>();
            builder.Services.AddScoped<RaceTraitService>();
            builder.Services.AddScoped<LanguageService>();
            builder.Services.AddScoped<CharacterService>();
            builder.Services.AddScoped<StatModifierService>();
            builder.Services.AddScoped<CharClassService>();
            builder.Services.AddScoped<CampaignService>();
            #endregion

            builder.Services.AddScoped<IAuthorizationHandler, IsGMHandler>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
                    
                    ValidateLifetime = true,

                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["Jwt:Audience"],

                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],

                };
            });

            builder.Services.AddAuthorization(option =>
            {
                option.AddPolicy("IsGM", policy => policy.AddRequirements(new IsGMRequirement()));
            });

            builder.Services.AddDbContext<RolePlayHelperContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            var app = builder.Build();

            AppSeeder.SeedDefaultCharacter(app.Services);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
