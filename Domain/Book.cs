namespace DefaultNamespace;

public class Book
{
    private string _isbn;
    private string _title;
    private string _author;
    private int _year;

    public string ISBN => _isbn;
    public string Title => _title;
    public string Author => _author;
    public int Year => _year;

    public Book(string isbn, string title, string author, int year)
    {
        _isbn = isbn;
        _title = title;
        _author = author;
        _year = year;
    }

    public override string ToString()
    {
        return $"{Title} by {Author} ({Year})";
    }
}