using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.Options;
using TheShelf.Data;
using TheShelf.Models;
using TheShelf.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private TheShelfDbContext _dbContext;
    private OMBDSettings _ombdSettings;

    public MovieController(TheShelfDbContext context, IOptions<OMBDSettings> ombdSettings)
    {
        _dbContext = context;
        _ombdSettings = ombdSettings.Value;
    }

    [HttpGet]
    public IActionResult GetMovies()
    {
        List<MovieDTO> foundMovies = _dbContext
            .Movies.Select(m => new MovieDTO
            {
                Id = m.Id,
                UserId = m.UserId,
                Title = m.Title,
                Genre = m.Genre,
            })
            .ToList();
        return Ok(foundMovies);
    }

    [HttpGet("search/{title}")]
    public async Task<IActionResult> GetMovieByTitleFromOMBD(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return BadRequest("Movie Title is required.");
        }
        var ApiKey = _ombdSettings.ApiKey;
        var Url = _ombdSettings.Url;
        Console.WriteLine($"OMDB URL: {Url}");
        Console.WriteLine($"OMDB ApiKey: {ApiKey}");
        var apiUrl = $"{Url}/?apikey={ApiKey}&t={title}&type=movie";

        try
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest("Error getting response from OMBD");
            }
            var movieData = await response.Content.ReadAsStringAsync();
            var parsedMovieData = JsonSerializer.Deserialize<object>(movieData);
            return Ok(parsedMovieData);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public IActionResult PostMovieToLocalDatabase(Movie newMovie)
    {
        try
        {
            _dbContext.Movies.Add(newMovie);
            _dbContext.SaveChanges();
            return NoContent();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest();
        }
    }
}
