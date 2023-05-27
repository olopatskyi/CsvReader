using AutoMapper;
using CSVReader.Application.Shared;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CSVReader.Application.MapperProfiles.Convertors;

public class ModelStateConverter : ITypeConverter<ModelStateDictionary, AppResponse>
{
    public AppResponse Convert(ModelStateDictionary source, AppResponse destination, ResolutionContext context)
    {
        var errors = source.Select(x => new AppError()
        {
            Property = x.Key,
            Messages = x.Value?.Errors.Select(e => e.ErrorMessage)
        });

        return new AppResponse()
        {
            StatusCode = 404,
            Errors = errors
        };
    }
}