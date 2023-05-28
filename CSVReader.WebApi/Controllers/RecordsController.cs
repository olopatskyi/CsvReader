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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByFileIdAsync(string fileId)
    {
        var records = await _recordsService.GetByFileIdAsync(fileId);
        
        return Ok(records);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateRecordVM model)
    {
        var result = await _recordsService.CreateAsync(model);

        return Ok(result);
    }
}