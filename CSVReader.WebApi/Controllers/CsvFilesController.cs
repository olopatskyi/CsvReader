using CSVReader.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSVReader.WebApi.Controllers;

[Route("api/v1/files")]
[ApiController]
public class CsvFilesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync()
    {
        throw new KeyNotFoundException();
        return Ok();
    }
}