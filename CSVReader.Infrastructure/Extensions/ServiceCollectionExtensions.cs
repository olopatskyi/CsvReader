using CSVReader.Domain.Entities;
using CSVReader.Domain.Interfaces;
using CSVReader.Domain.Settings;
using CSVReader.Infrastructure.DataAccess;
using CSVReader.Infrastructure.Factories;
using CSVReader.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CSVReader.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, Func<DatabaseSettings> connectionConfiguration)
    {
        var conf = connectionConfiguration();

        if (conf is null)
        {
            throw new NullReferenceException(nameof(conf));
        }
        
        var connectionString = $@"Server={conf.Server};Database={conf.Database};User Id={conf.UserId};Password={conf.Password};TrustServerCertificate=true;";
        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        return services;
    }
    
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IRowRecordRepository, RowRecordRepository>();
        return services;
    }

    public static IServiceCollection AddFilters(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IFilterFactory<RowRecord>), typeof(RowRecordFactory));

        return services;
    }
}