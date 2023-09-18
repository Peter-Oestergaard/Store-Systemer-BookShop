using BookStore.DTOs;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace BookStore.Controllers;

/// <summary>
/// 
/// </summary>
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class AuthorsController : ControllerBase
{
    /// <summary>
    /// List all authors
    /// </summary>
    /// <returns>All the authors</returns>
    [HttpGet(Name = "Authors")]
    [ProducesResponseType(typeof(IEnumerable<AuthorDto>), 200)]
    public IActionResult GetAuthors()
    {
        return Ok(new List<AuthorDto> { new AuthorDto { Id = 1, Name = "Thomas Helmig"} });
    }

    /// <summary>
    /// Get specific author
    /// </summary>
    /// <returns>An authors</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IEnumerable<AuthorDto>), 200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetAuthor(int id)
    {
        return id == 0 ? NotFound() : Ok(new AuthorDto { Id = id, Name = "Valdemar Atterdag" });
    }

    /// <summary>
    /// Get books by author
    /// </summary>
    /// <returns>Books</returns>
    [HttpGet("{id}/books")]
    [ProducesResponseType(typeof(IEnumerable<BookDto>), 200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetBooksByAuthor(int id)
    {
        return id == 0 ? NotFound() : Ok(new List<BookDto>{ new BookDto { Id = id, Title = "Pepsi Max Lime er godt" } });
    }
}
