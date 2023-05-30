using CSVReader.Application.Interfaces;
using CSVReader.Application.Models.RowRecord;
using Microsoft.AspNetCore.Mvc;

namespace CSVReader.WebApi.Controllers;

[ApiController]
[Route("api/v1/files/{fileId}/records")]
public class RecordsController : ControllerBase
{
    private readonly IRecordsService _recordsService;

    public RecordsController(IRecordsService recordsService)
    {
        _recordsService = recordsService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetRecords(Guid fileId)
    {
        var result = await _recordsService.GetByFileIdAsync(fileId);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRecordAsync(Guid id)
    {
        var result = await _recordsService.GetByIdAsync(id);

        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateRecordVM model)
    {
        var result = await _recordsService.CreateAsync(model);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateRecordVM model)
    {
        var result = await _recordsService.UpdateAsync(id, model);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _recordsService.DeleteAsync(id);
        
        return Ok(result); //Should be NoContent, but there is already 204 status code in response body
    }
}