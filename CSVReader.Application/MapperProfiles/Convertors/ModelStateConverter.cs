using AutoMapper;
using CSVReader.Domain.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CSVReader.Application.MapperProfiles.Convertors;

public class ModelStateConverter : ITypeConverter<ModelStateDictionary, AppResponse>
{
    public AppResponse Convert(ModelStateDictionary source, AppResponse destination, ResolutionContext context)
    {
        var errors = new List<AppError>();
        foreach (var item in source)
        {
            foreach (var value in item.Value.Errors)
            {
                errors.Add(new AppError(item.Key, value.ErrorMessage));
            }
        }
        
        return new AppResponse()
        {
            StatusCode = 400,
            Errors = errors
        };
    }
}