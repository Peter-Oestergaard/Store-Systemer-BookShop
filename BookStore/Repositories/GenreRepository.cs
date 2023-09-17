using BookStore.Interfaces;
using BookStore.Models;

internal class GenreRepository : IRepository<Genre>
{
    List<Genre> genres = new() {
        new Genre(1, "SciFi"),
        new Genre(2, "Romance"),
        new Genre(3, "Tech noir")
    };

    public IEnumerable<Genre> Where(Func<Genre, bool> clause)
    {
        var result = genres.Where(clause);
        return result;
    }

    public Genre? FirstOrDefault(Func<Genre, bool> clause)
    {
        Genre? result = genres.FirstOrDefault(clause);
        return result;
    }
}