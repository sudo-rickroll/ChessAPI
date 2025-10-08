using ChessConnect.Interfaces;
using ChessConnect.Models;

namespace ChessConnect.Services
{
    public class ArchivesService(IArchiveRepository archiveRepository)
    {
        private readonly IArchiveRepository _archiveRepository = archiveRepository;
        public async Task<Archive?> GetArchives(string playerName)
        {
            return await _archiveRepository.GetArchivesAsync(playerName);

        }
    }
}