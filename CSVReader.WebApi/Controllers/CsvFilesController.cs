using CSVReader.Application.Interfaces;
using CSVReader.Application.Models;
using CSVReader.Application.Models.CsvFile;
using CSVReader.Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CSVReader.WebApi.Controllers;

[Route("api/v1/files")]
[ApiController]
public class CsvFilesController : ControllerBase
{
    private readonly ICsvFileService _csvFileService;

    public CsvFilesController(ICsvFileService csvFileService)
    {
        _csvFileService = csvFileService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _csvFileService.GetByIdAsync(id);

        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CreateFileVM model)
    {
        var result = await _csvFileService.CreateAsync(model);
        
        return Created(string.Empty, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateFileVM model)
    {
        var result = await _csvFileService.UpdateAsync(id, model);
        
        return Ok(result);
    }
    
    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchAsync(Guid id, [FromBody] JsonPatchDocument<CsvFile> patchDocument)
    {
        var result = await _csvFileService.PatchAsync(id, patchDocument);
        
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _csvFileService.DeleteAsync(id);
        
        return Ok(result); // Should be NoContent, but we should output body
    }
}