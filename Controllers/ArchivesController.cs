using Microsoft.AspNetCore.Mvc;
using ChessConnect.Services;

namespace ChessConnect.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ArchivesController(MonthlyArchivesService service, ILogger<ArchivesController> logger
                                    ) : ControllerBase
    {
        private readonly MonthlyArchivesService _service = service;
        private readonly ILogger<ArchivesController> _logger = logger;

        [HttpGet]
        [Route("{playerName}")]
        public async Task<IActionResult> Get(string playerName)
        {
            try
            {
                _logger.LogInformation("Received request to get monthly archives for {Player}",

                                        playerName
                                        );
                Archive? archives = await _service.GetArchivesAsync(playerName);
                return Ok(archives);
            }
            catch (Exception e)
            {
                _logger.LogError("Unable to make request for {Player}: {Error}",
                                    playerName,
                                    e.Message
                                );
                return NotFound();
            }
        }
    }
}
