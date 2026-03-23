namespace DefaultNamespace;

public interface IRecommendationtrategy
{
    public interface IRecommendationStrategy
    {
        List<Book> GetRecommendations(Member member, List<Member> allMembers, List<Book> allBooks, int topN);
    }
}