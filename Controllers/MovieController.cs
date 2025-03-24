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
            .Movies.Select(m => new MovieDTO { Id = m.Id, imbdId = m.imbdId })
            .ToList();
        return Ok(foundMovies);
    }

    //Get movie from OMDB by the title

    [HttpGet("search/{title}/{page}")]
    public async Task<IActionResult> GetMovieByTitleFromOMBD(string title, int page = 1)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return BadRequest("Movie Title is required.");
        }
        var ApiKey = _ombdSettings.ApiKey;
        var Url = _ombdSettings.Url;
        Console.WriteLine($"OMDB URL: {Url}");
        Console.WriteLine($"OMDB ApiKey: {ApiKey}");
        var apiUrl = $"{Url}/?apikey={ApiKey}&s={title}&type=movie&page={page}";

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

    //Get a movie from its IMDB Id from OMBD

    [HttpGet("search/id={imbdId}")]
    public async Task<IActionResult> GetMovieByImbdIdFromOMBD(string imbdId)
    {
        Console.WriteLine($"Received ImbdId: {imbdId}");

        if (string.IsNullOrWhiteSpace(imbdId))
        {
            return BadRequest("ImdbId required.");
        }
        var ApiKey = _ombdSettings.ApiKey;
        var Url = _ombdSettings.Url;
        Console.WriteLine($"OMDB URL: {Url}");
        Console.WriteLine($"OMDB ApiKey: {ApiKey}");
        var apiUrl = $"{Url}/?apikey={ApiKey}&i={imbdId}";

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
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
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

    [HttpGet("{id}")]
    public IActionResult getMovieById(int id)
    {
        MovieDTO foundMovie = _dbContext
            .Movies.Where(m => m.Id == id)
            .Select(m => new MovieDTO { Id = m.Id, imbdId = m.imbdId })
            .FirstOrDefault();

        if (foundMovie == null)
        {
            return BadRequest();
        }
        return Ok(foundMovie);
    }
}
