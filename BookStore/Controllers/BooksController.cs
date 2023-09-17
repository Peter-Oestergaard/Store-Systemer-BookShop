using System.Collections;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class BooksController : ControllerBase
{
    private readonly ILogger<BooksController> _logger;

    public BooksController(ILogger<BooksController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Give me all them books
    /// </summary>
    /// <param name="genres"></param>
    /// <param name="authors"></param>
    /// <returns>All them books</returns>
    [HttpGet(Name = "Books")]
    public IEnumerable<Book> GetBook(string? genres, string? authors)
    {
        return new List<Book> { new() {Id = 1}};
    }
    
    /// <summary>
    /// Give me just this book
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Just that book</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Book), 200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetBook(int id)
    {
        if (id == 0) return NotFound();
        return Ok(new Book {Id = id});
    }
    
    /// <summary>
    /// Give me the reviews for just this book
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Reviews for just that book</returns>
    [HttpGet("{id}/reviews")]
    public IEnumerable<Review> GetBookReviews(int id)
    {
        return new List<Review> { new() {Id = 1+id}, new() {Id = 2+id}};
    }
}