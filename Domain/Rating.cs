namespace DefaultNamespace;

public class Rating
{
    private Book _book;
    private Member _member;
    private RatingValue _value;

    public Book Book => _book;
    public Member Member => _member;
    public RatingValue Value => _value;

    public Rating(Member member, Book book, RatingValue value)
    {
        _member = member;
        _book = book;
        _value = value;
    }

    public override string ToString() => $"{Book.Title}: {Value}";
}