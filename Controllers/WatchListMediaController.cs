using Microsoft.AspNetCore.Mvc;
using TheShelf.Data;
using TheShelf.Models;
using TheShelf.Models.DTOs;

[ApiController]
[Route("/api/[controller]")]
public class WatchListMediaController : ControllerBase
{
    private TheShelfDbContext _dbContext;

    public WatchListMediaController(TheShelfDbContext context)
    {
        _dbContext = context;
    }

    [HttpPost]
    public IActionResult PostAWatchlistMedia(WatchListMedia newWatchlistMedia)
    {
        _dbContext.WatchListMedias.Add(newWatchlistMedia);
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpGet]
    public IActionResult GetAllWatchlistMedia(int watchlistId)
    {
        List<WatchListMediaDTO> allWatchlistMediaByWatchlistId = _dbContext
            .WatchListMedias.Where(wlm => wlm.WatchListId == watchlistId)
            .Select(wlm => new WatchListMediaDTO
            {
                Id = wlm.Id,
                WatchListId = wlm.WatchListId,
                MovieId = wlm.MovieId,
            })
            .ToList();

        return Ok(allWatchlistMediaByWatchlistId);
    }

    [HttpDelete]
    public IActionResult DeleteAWatchlistMedia(int watchlistId, int movieId)
    {
        var foundWatchlist = _dbContext.WatchListMedias.SingleOrDefault(wl =>
            wl.WatchListId == watchlistId && wl.MovieId == movieId
        );
        if (foundWatchlist == null)
        {
            return BadRequest();
        }

        _dbContext.WatchListMedias.Remove(foundWatchlist);
        _dbContext.SaveChanges();
        return NoContent();
    }
}
