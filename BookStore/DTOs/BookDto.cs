using BookStore.Models;

namespace BookStore.DTOs;

/// <summary>
/// 
/// </summary>
public class BookDto
{
    /// <summary>
    /// 
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// 
    /// </summary>
    public List<Genre>? Genres { get; set; }
}
