using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using CSVReader.Application.Extensions;
using CSVReader.Application.Shared;
using CSVReader.Domain.Models;
using CSVReader.Domain.Settings;
using CSVReader.Infrastructure.Extensions;
using CSVReader.WebApi.Extensions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CSVReader.WebApi;

public class Startup
{
    private IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });
        
        services.ConfigureBadRequestResponse();
        
        services
            .AddSwagger()
            .AddSettings(Configuration)
            .AddJwtAuthentication()
            .AddValidation()
            .AddMapper()
            .AddDatabase(() => new DatabaseSettings()
            {
                Server = Configuration.GetValue<string>("DatabaseSettings:Server"),
                Database = Configuration.GetValue<string>("DatabaseSettings:Database"),
                UserId = Configuration.GetValue<string>("DatabaseSettings:UserId"),
                Password = Configuration.GetValue<string>("DatabaseSettings:Password"),
            })
            .AddRepositories()
            .AddServices()
            .AddFilters();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
           
        }

        app.UseMiddleware<ExceptionHandlerMiddleware>();

        app.UseSwagger();
        app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "CSV File Editor"); });

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();
        
        
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}