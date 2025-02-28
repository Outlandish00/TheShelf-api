using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheShelf.Data;
using TheShelf.Models;
using TheShelf.Models.DTOs;

[ApiController]
[Route("/api/[controller]")]
public class WatchlistController : ControllerBase
{
    private TheShelfDbContext _dbContext;

    public WatchlistController(TheShelfDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    public IActionResult GetUsersWatchlist(int? userId)
    {
        var UserWatchlist = _dbContext
            .Watchlists.Where(w => w.UserId == userId)
            .Include(w => w.WatchListMedia)
            .ThenInclude(wm => wm.Movie)
            .Select(w => new WatchListDTO
            {
                Id = w.Id,
                Title = w.Title,
                UserId = w.UserId,
                IsPrivate = w.IsPrivate,
                WatchlistMedia = w
                    .WatchListMedia.Select(wm => new WatchListMediaDTO
                    {
                        Id = wm.Id,
                        WatchListId = wm.WatchListId,
                        MovieId = wm.MovieId,
                        Movie = new MovieDTO
                        {
                            Id = wm.Movie.Id,
                            UserId = wm.Movie.UserId,
                            Title = wm.Movie.Title,
                            Genre = wm.Movie.Genre,
                        },
                    })
                    .ToList(),
            })
            .ToList();

        return Ok(UserWatchlist);
    }

    [HttpGet("{id}")]
    public IActionResult GetWatchlistById(int id)
    {
        WatchListDTO foundWatchlist = _dbContext
            .Watchlists.Where(wl => wl.Id == id)
            .Include(wl => wl.WatchListMedia)
            .ThenInclude(wlm => wlm.Movie)
            .Select(wl => new WatchListDTO
            {
                Id = wl.Id,
                Title = wl.Title,
                UserId = wl.UserId,
                IsPrivate = wl.IsPrivate,
                WatchlistMedia = wl
                    .WatchListMedia.Select(wlm => new WatchListMediaDTO
                    {
                        Id = wlm.Id,
                        WatchListId = wlm.WatchListId,
                        MovieId = wlm.MovieId,
                        Movie = new MovieDTO
                        {
                            Id = wlm.Movie.Id,
                            UserId = wlm.Movie.UserId,
                            Title = wlm.Movie.Title,
                            Genre = wlm.Movie.Genre,
                            Actors = wlm.Movie.Actors,
                            PosterLink = wlm.Movie.PosterLink,
                            Rating = wlm.Movie.Rating,
                            Rated = wlm.Movie.Rated,
                            ReleaseYear = wlm.Movie.ReleaseYear,
                            Director = wlm.Movie.Director,
                        },
                    })
                    .ToList(),
            })
            .FirstOrDefault();

        return Ok(foundWatchlist);
    }

    [HttpPost]
    public IActionResult PostWatchlist(WatchList newWatchlist)
    {
        Console.WriteLine("PostWatchlist method called");
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(newWatchlist));
        try
        {
            newWatchlist.WatchListMedia ??= new List<WatchListMedia>();
            _dbContext.Watchlists.Add(newWatchlist);
            _dbContext.SaveChanges();
            return NoContent();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAWatchlist(int id)
    {
        WatchList watchlistToDelete = _dbContext.Watchlists.SingleOrDefault(wl => wl.Id == id);
        if (watchlistToDelete == null)
        {
            return BadRequest();
        }
        _dbContext.Watchlists.Remove(watchlistToDelete);
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAWatchlist(int id, WatchList newWatchlist)
    {
        WatchList watchlistToUpdate = _dbContext
            .Watchlists.Where(wl => wl.Id == id)
            .SingleOrDefault();
        watchlistToUpdate.Title = newWatchlist.Title;
        watchlistToUpdate.IsPrivate = newWatchlist.IsPrivate;
        _dbContext.SaveChanges();
        return NoContent();
    }
}
