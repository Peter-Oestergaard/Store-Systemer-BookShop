using BookStore.DTOs;
using BookStore.Interfaces;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

/// <summary>
/// 
/// </summary>
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class BooksController : ControllerBase
{
    private readonly ILogger<BooksController> _logger;
    private readonly IRepository<Book> _bookRepository;
    private readonly IRepository<Genre> _genreRepository;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="bookRepository"></param>
    /// <param name="genreRepository"></param>
    public BooksController(ILogger<BooksController> logger, IRepository<Book> bookRepository, IRepository<Genre> genreRepository)
    {
        _logger = logger;
        _bookRepository = bookRepository;
        _genreRepository = genreRepository;
    }

    /// <summary>
    /// Give me all them books
    /// </summary>
    /// <param name="genres">Comma separated list of genres. E.g. "Scifi,romance,noir"</param>
    /// <param name="authors">Comma separated list of authors. E.g. "King,Coonz,Reuter"</param>
    /// <returns>All them books</returns>
    [HttpGet(Name = "Books")]
    [ProducesResponseType(typeof(IEnumerable<BookDto>), 200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetBooks(string? genres, string? authors)
    {
        List<string> searchGenres = genres?.Split(',').ToList() ?? new();
        List<string> searchAuthors = authors?.Split(',').ToList() ?? new();

        IEnumerable<Genre> genresFound = _genreRepository.Where(
            g => 
            searchGenres.Contains(g.Name)
            );

        //return _bookRepository.Where(book => (!ge.Any() || (book.Genres ?? new()).Any(bg => ge.Contains(bg.Name))) && (!au.Any() || (book.Authors ?? new()).Any(ba => au.Contains(ba.Name))));
        IEnumerable<Book> books = _bookRepository.Where(book => (
            !searchGenres.Any() // If search term is empty we don't filter for it.
            || (book.GenreIds ?? new()) // To avoid null reference exceptions we create a new empty list
                .Any(genreId => genresFound.Any(g => g.id == genreId)))
                && !searchAuthors.Any()); // TODO(PETER): Do author search

        if (!books.Any())
        {
            return NotFound();
        };

        return Ok(books.Select(book => new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Genres = book.GenreIds?.Select(g => new Genre(g, _genreRepository.FirstOrDefault(fg => fg.id == g)?.Name!)).ToList()
        }).ToList());
        //return new List<BookDto>() { new BookDto() { Id = 1, Title = "Mis", Genres = null } };
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
        return Ok(new Book(id, "Title{id}") );
    }
    
    /// <summary>
    /// Give me the reviews for just this book
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Reviews for just that book</returns>
    [HttpGet("{id}/reviews")]
    public IEnumerable<Review> GetBookReviews(int id)
    {
        return new List<Review> { new(1+id), new(2+id)};
    }

    /// <summary>
    /// Give me this review for this book
    /// </summary>
    /// <param name="bookId">Unique id of book to get review from</param>
    /// /// <param name="reviewId">Unique id of review to get - (If reviews have unique ids why do we need to state the book id?)</param>
    /// <returns>A review for a single book</returns>
    [HttpGet("{bookId}/reviews/{reviewId}")]
    public Review GetBookReview(int bookId, int reviewId)
    {
        return new Review(bookId + reviewId);
    }
}