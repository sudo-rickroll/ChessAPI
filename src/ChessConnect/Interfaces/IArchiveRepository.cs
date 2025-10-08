using ChessConnect.Models;

namespace ChessConnect.Interfaces;

public interface IArchiveRepository
{
    Task<Archive?> GetArchivesAsync(string playerName);
}
