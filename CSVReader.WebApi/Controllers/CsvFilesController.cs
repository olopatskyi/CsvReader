using CSVReader.Application.Interfaces;
using CSVReader.Application.Models;
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
    public async Task<IActionResult> GetByIdAsync(string id)
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
    public async Task<IActionResult> UpdateAsync(string id)
    {
        return Ok();
    }
    
    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchAsync(string id, [FromBody] JsonPatchDocument<CsvFile> patchDocument)
    {
        var result = await _csvFileService.PatchAsync(id, patchDocument);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        return Ok();
    }
}