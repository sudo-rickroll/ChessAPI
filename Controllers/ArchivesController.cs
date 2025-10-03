using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/[controller]")]
public class ArchivesController(MonthlyArchivesService service) : ControllerBase
{
    private readonly MonthlyArchivesService _service = service;

    [HttpGet]
    [Route("{playerName}")]
    public async Task<IActionResult> Get(string playerName)
    {
        Archive? archives = await _service.GetArchivesAsync(playerName);
        return Ok(archives);
    }
}