namespace DefaultNamespace;

public class BookRepository
{
   private List<Book> _books = new List<Book>();

   public void Add(Book book) 
   {
      _books.Add(book);
   }

   public List<Book> GetAll() 
   {
      return _books;
   }

   public Book GetByISBN(string isbn) 
   {
      return _books.Find(b => b.ISBN == isbn);
   }
}
