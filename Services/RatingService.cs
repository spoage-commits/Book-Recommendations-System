namespace DefaultNamespace;

public class RatingService
{
    private IMemberRepository _memberRepo;
    private IBookRepository _bookRepo;

    public RatingService(IMemberRepository memberRepo, IBookRepository bookRepo)
    {
        _memberRepo = memberRepo;
        _bookRepo = bookRepo;
    }

    public void AddRating(Member member, Book book, RatingValue value)
    {
      
    }

    public List<Rating> GetRatingsForMember(Member member)
    {
        return new List<Rating>();
    }
}