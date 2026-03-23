namespace DefaultNamespace;

public interface IBookRepository
{
    void Add(Book book);
    List<Book> GetAll();
    Book GetByISBN(string isbn);
}
