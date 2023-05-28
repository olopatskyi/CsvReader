using System.Reflection;
using AutoMapper;
using CSVReader.Application.Interfaces;
using CSVReader.Application.Services;
using CSVReader.Domain.Entities;
using CSVReader.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CSVReader.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddIdentity(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddIdentityCore<AppUser>()
            .AddRoles<AppRole>()
            .AddEntityFrameworkStores<DatabaseContext>()
            .AddDefaultTokenProviders();
        
        return serviceCollection;
    }

    public static IServiceCollection AddMapper(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(typeof(ICsvFileService));

        return serviceCollection;
    }
    
    public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<ICsvFileService, CsvFileService>();
        serviceCollection.AddTransient<IRecordsService, RecordsService>();
        
        return serviceCollection;
    }
}