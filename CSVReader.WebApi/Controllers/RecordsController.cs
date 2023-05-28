using CSVReader.Application.Interfaces;
using CSVReader.Application.Models.RowRecord;
using Microsoft.AspNetCore.Mvc;

namespace CSVReader.WebApi.Controllers;

[ApiController]
[Route("api/v1/records")]
public class RecordsController : ControllerBase
{
    private readonly IRecordsService _recordsService;

    public RecordsController(IRecordsService recordsService)
    {
        _recordsService = recordsService;
    }

    [HttpGet("api/v1/files/{id}")]
    public async Task<IActionResult> GetByFileIdAsync(string fileId)
    {
        var records = await _recordsService.GetByFileIdAsync(fileId);
        
        return Ok(records);
    }

    [HttpGet("{fileId}")]
    public async Task<IActionResult> GetRecords(string fileId)
    {
        var result = await _recordsService.GetByFileIdAsync(fileId);

        return Ok(result);
    }
    
    [HttpGet("")]
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateRecordVM model)
    {
        var result = await _recordsService.CreateAsync(model);

        return Ok(result);
    }
}