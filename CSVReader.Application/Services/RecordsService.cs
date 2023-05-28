using System.Net;
using AutoMapper;
using CSVReader.Application.Interfaces;
using CSVReader.Application.Models.RowRecord;
using CSVReader.Domain.Entities;
using CSVReader.Domain.Exceptions;
using CSVReader.Domain.Interfaces;
using CSVReader.Domain.Models;

namespace CSVReader.Application.Services;

public class RecordsService : IRecordsService
{
    private readonly IRowRecordRepository _repository;
    private readonly IMapper _mapper;

    public RecordsService(IRowRecordRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AppResponse<IEnumerable<RowRecord>>> GetByFileIdAsync(string fileId)
    {
        var records = await _repository.GetAsync(x => x.CsvFileId == Guid.Parse(fileId));

        return new AppResponse<IEnumerable<RowRecord>>(HttpStatusCode.OK, null, records);
    }

    public async Task<AppResponse<RowRecordVM>> GetByIdAsync(string id)
    {
        var record = await GetRecordAsync(Guid.Parse(id));

        var data = _mapper.Map<RowRecordVM>(record);
        return new AppResponse<RowRecordVM>(HttpStatusCode.OK, null, data);
    }

    public async Task<AppResponse> CreateAsync(CreateRecordVM model)
    {
        var record = _mapper.Map<RowRecord>(model);

        await _repository.CreateAsync(record);
        await _repository.SaveAsync();
        
        return new AppResponse(HttpStatusCode.Created, null);
    }

    public async Task<AppResponse<RowRecordVM>> UpdateAsync(string id, UpdateRecordVM model)
    {
        var record = await GetRecordAsync(Guid.Parse(id));
        _mapper.Map(model, record);

        _repository.Update(record);
        await _repository.SaveAsync();

        var data = _mapper.Map<RowRecordVM>(record);
        return new AppResponse<RowRecordVM>(HttpStatusCode.OK, null, data);
    }

    public async Task<AppResponse> DeleteAsync(string id)
    {
        var record = await GetRecordAsync(Guid.Parse(id));

        _repository.Delete(record);
        await _repository.SaveAsync();

        return new AppResponse(HttpStatusCode.NoContent, null);
    }

    private async Task<RowRecord> GetRecordAsync(Guid id)
    {
        var record = await _repository.FirstOrDefaultAsync(x => x.Id == id);

        if (record == null)
        {
            throw NotFoundException.Default<RowRecord>();
        }

        return record;
    }
}