using BookStore.Interfaces;
using BookStore.Models;

internal class BookRepository : IRepository<Book>
{
    List<Book> books = new() {
        new Book(1, "Space invaders") {GenreIds = new() { 1 } }, new Book(2, "Blah blah blah"), new Book(3, "Cooking with Tim")
    };

    public Genre? FirstOrDefault(Func<Genre, bool> clause)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Book> Where(Func<Book, bool> clause)
    {
        return books.Where(clause);
    }
}