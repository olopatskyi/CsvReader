using AutoMapper;
using CSVReader.Application.Models.RowRecord;
using CSVReader.Domain.Entities;

namespace CSVReader.Application.MapperProfiles;

public class RowRecordProfile : Profile
{
    public RowRecordProfile()
    {
        CreateMap<CreateRecordVM, RowRecord>(MemberList.Source);

        CreateMap<RowRecord, RowRecordVM>(MemberList.Destination);

        CreateMap<UpdateRecordVM, RowRecord>(MemberList.Source);
    }
}