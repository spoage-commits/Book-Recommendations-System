namespace DefaultNamespace;

public class Member
{
    private string _accountId;
    private string _name;
    private List<Rating> _ratings;

    public string AccountId => _accountId;
    public string Name => _name;
    public IReadOnlyList<Rating> Ratings => _ratings.AsReadOnly();

    public Member(string accountId, string name)
    {
        _accountId = accountId;
        _name = name;
        _ratings = new List<Rating>();
    }

    public void AddRating(Rating rating)
    {
        _ratings.Add(rating);
    }

    public RatingValue GetRating(Book book)
    {
        var rating = _ratings.FirstOrDefault(r => r.Book.ISBN == book.ISBN);
        return rating != null ? rating.Value : RatingValue.HaventRead;
    }

    public override string ToString() => $"{Name} ({AccountId})";
}