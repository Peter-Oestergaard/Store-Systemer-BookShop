using BookStore.Interfaces;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

/// <summary>
/// 
/// </summary>
[Route("[controller]")]
[ApiController]
[Produces("application/json")]
public class GenresController : ControllerBase
{
    private readonly ILogger<GenresController> _logger;
    private readonly IRepository<Genre> _genreRepository;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="genreRepository"></param>
    public GenresController(ILogger<GenresController> logger, IRepository<Genre> genreRepository)
    {
        _logger = logger;
        _genreRepository = genreRepository;
    }

    /// <summary>
    /// Give me all them genres
    /// </summary>
    /// <param name="genres">Comma separated list of genres. E.g. "Scifi,romance,noir"</param>
    /// <returns>All them genres</returns>
    [HttpGet(Name = "Genres")]
    public IEnumerable<Genre> GetGenres(string? genres)
    {
        List<string> searchGenres = genres?.Split(',').ToList() ?? new();

        //return _bookRepository.Where(book => (!ge.Any() || (book.Genres ?? new()).Any(bg => ge.Contains(bg.Name))) && (!au.Any() || (book.Authors ?? new()).Any(ba => au.Contains(ba.Name))));
        return _genreRepository.Where(genre => !searchGenres.Any());
    }
}
