using Moq;
using FluentAssertions;
using ChessConnect.Services;
using ChessConnect.Interfaces;
using ChessConnect.Models;

namespace ChessConnect.Tests;

public class ArchiveServiceTests
{
    private readonly ArchiveService _archiveService;
    private readonly Mock<IArchiveRepository> _archiveRepositoryMock;

    public ArchiveServiceTests()
    {
        _archiveRepositoryMock = new Mock<IArchiveRepository>();
        _archiveService = new ArchiveService(_archiveRepositoryMock.Object);
    }

    [Fact]
    public async void GetArchives_ShouldReturnArchives_WhenPlayerExists()
    {
        var player = "test";
        int year = DateTime.Now.Year;
        int month = DateTime.Now.Month;
        var expectedArchive = new Archive(Archives: [$"http://api.chess.com/pub/player/{player}/games/{year}/{month}"]);
        _archiveRepositoryMock.Setup(repo => repo.GetArchivesAsync(player)).ReturnsAsync(expectedArchive);

        var receivedArchive = await _archiveService.GetArchives(player);

        receivedArchive.Should().NotBeNull();
        receivedArchive.Should().BeEquivalentTo(expectedArchive);
    }

    [Fact]
    public async void GetArchives_ShouldReturnNull_WhenPlayerDoesNotExist()
    {
        var player = "test_NA";
        _archiveRepositoryMock.Setup(repo => repo.GetArchivesAsync(player)).ReturnsAsync((Archive?)null);

        var receivedArchive = await _archiveService.GetArchives(player);

        receivedArchive.Should().BeNull();

    }
}