using CSVReader.Application.Interfaces;
using CSVReader.Application.Models;
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

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CreateFileVM model)
    {
        var result = await _csvFileService.CreateAsync(model);
        
        return Created(string.Empty, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(string id)
    {
        var result = await _csvFileService.GetByIdAsync(id);

        return Ok(result);
    }
}