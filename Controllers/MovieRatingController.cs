using Microsoft.AspNetCore.Mvc;
using TheShelf.Data;
using TheShelf.Models;
using TheShelf.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class MovieRatingController : ControllerBase
{
    private TheShelfDbContext _dbContext;

    public MovieRatingController(TheShelfDbContext context)
    {
        _dbContext = context;
    }

    [HttpPost]
    public IActionResult PostNewMovieRating(MovieRating newMovieRating)
    {
        try
        {
            _dbContext.Add(newMovieRating);
            _dbContext.SaveChanges();
            return NoContent();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpGet("{movieId}")]
    public IActionResult GetMovieRatingsBasedOnMovieId(int movieId)
    {
        try
        {
            List<MovieRatingDTO> foundMovieRatings = _dbContext
                .MovieRatings.Where(mr => mr.MovieId == movieId)
                .Select(mr => new MovieRatingDTO
                {
                    Id = mr.Id,
                    MovieId = mr.MovieId,
                    UserId = mr.UserId,
                    Rating = mr.Rating,
                })
                .ToList();
            return Ok(foundMovieRatings);
        }
        catch
        {
            return BadRequest();
        }
    }
}
