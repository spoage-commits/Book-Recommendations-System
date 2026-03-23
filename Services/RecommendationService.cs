namespace DefaultNamespace;

public class RecommendationService
{
    public class RecommendationService
    {
        private IMemberRepository _memberRepo;
        private IBookRepository _bookRepo;
        private IRecommendationStrategy _strategy;

        public RecommendationService(IMemberRepository memberRepo, IBookRepository bookRepo, IRecommendationStrategy strategy)
        {
            _memberRepo = memberRepo;
            _bookRepo = bookRepo;
            _strategy = strategy;
        }

        public List<Book> GetRecommendations(Member member, int topN)
        {
            return new List<Book>();
        }
    }
}