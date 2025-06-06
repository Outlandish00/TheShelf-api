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
        if (watchlistId != null)
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
        List<WatchListMediaDTO> allwatchlistMeida = _dbContext
            .WatchListMedias.Select(wlm => new WatchListMediaDTO
            {
                Id = wlm.Id,
                WatchListId = wlm.WatchListId,
                MovieId = wlm.MovieId,
            })
            .ToList();
        return Ok(allwatchlistMeida);
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

    [HttpGet("/ids")]
    public IActionResult GetWatchlistMediaByTheTwoIds(int movieId, int watchlistId)
    {
        var foundMedia = _dbContext
            .WatchListMedias.Where(wlm => wlm.MovieId == movieId && wlm.WatchListId == watchlistId)
            .Select(wlm => new WatchListMediaDTO
            {
                Id = wlm.Id,
                WatchListId = wlm.WatchListId,
                MovieId = wlm.MovieId,
                Watchlist = new WatchListDTO
                {
                    Id = wlm.Watchlist.Id,
                    Title = wlm.Watchlist.Title,
                    UserId = wlm.Watchlist.UserId,
                    IsPrivate = wlm.Watchlist.IsPrivate,
                },
            })
            .FirstOrDefault();
        if (foundMedia == null)
        {
            return BadRequest();
        }
        return Ok(foundMedia);
    }
}
