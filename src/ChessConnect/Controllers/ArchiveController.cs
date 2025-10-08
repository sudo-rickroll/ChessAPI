using Microsoft.AspNetCore.Mvc;
using ChessConnect.Services;
using ChessConnect.Models;

namespace ChessConnect.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ArchiveController(ArchiveService service, ILogger<ArchiveController> logger
                                ) : ControllerBase
{
    private readonly ArchiveService _service = service;
    private readonly ILogger<ArchiveController> _logger = logger;

    [HttpGet]
    [Route("{playerName}")]
    public async Task<IActionResult> Get(string playerName)
    {
        _logger.LogInformation("Received request to get monthly archives for {Player}",
                                    playerName
                                );
        Archive? archives = await _service.GetArchives(playerName);
        return archives == null ? StatusCode(500, "Internal server error") : Ok(archives);
    }
}
