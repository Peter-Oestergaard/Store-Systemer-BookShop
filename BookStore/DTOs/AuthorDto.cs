using BookStore.Models;

namespace BookStore.DTOs;

/// <summary>
/// 
/// </summary>
public class AuthorDto
{
    /// <summary>
    /// 
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// 
    /// </summary>
    public List<Book>? Books { get; set; }
}
