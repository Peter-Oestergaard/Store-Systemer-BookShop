namespace BookStore.Models;

/// <summary>
/// 
/// </summary>
public record Book(int Id, string Title)
{
    /// <summary>
    /// 
    /// </summary>
    public List<int>? GenreIds { get; internal set; }

    /// <summary>
    /// 
    /// </summary>
    public List<int>? Authors { get; internal set; }
}
