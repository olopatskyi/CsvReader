using System.Reflection;
using System.Text;
using AutoMapper;
using CSVReader.Application.Shared;
using CSVReader.Domain.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace CSVReader.WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "CSV Reader API",
                Version = "v1",
                Description = "This API is for reading and editing csv files"
            });
        });

        return services;
    }

    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
    {
        var provider = services.BuildServiceProvider();
        var settings = provider.GetRequiredService<JwtSettings>();
        
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false; // Set to true in production
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = settings.ValidIssuer,
                    ValidAudience = settings.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.SecretKey)),
                    ClockSkew = TimeSpan.Zero
                };
            });
        
        return services;
    }

    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<Program>();
        return services;
    }

    public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.AddSingleton<JwtSettings>(opt =>
        {
            var service = opt.GetRequiredService<IOptions<JwtSettings>>().Value;
            return service;
        });
        
        return services;
    }

    public static void ConfigureBadRequestResponse(this IServiceCollection services)
    {
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = (context) =>
            {
                var mapper = context.HttpContext.RequestServices.GetRequiredService<IMapper>();
                options.SuppressModelStateInvalidFilter = true;

                return new BadRequestObjectResult(
                    mapper.Map<AppResponse>(mapper.Map<AppResponse>(mapper.Map<AppResponse>(context.ModelState))));
            };
        });
    }
}