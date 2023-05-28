using AutoMapper;
using CSVReader.Application.MapperProfiles.Convertors;
using CSVReader.Application.Shared;
using CSVReader.Domain.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CSVReader.Application.MapperProfiles;

public class ModelStateProfile : Profile
{
    public ModelStateProfile()
    {
        CreateMap<ModelStateDictionary, AppResponse>()
            .ConvertUsing<ModelStateConverter>();
    }
}