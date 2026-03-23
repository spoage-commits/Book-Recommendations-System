namespace DefaultNamespace;

public interface IMemberRepository
{
   void Add(Member member);
    List<Members> GetAll();
    Members GetById(int accountId);
}
