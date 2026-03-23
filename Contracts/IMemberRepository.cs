namespace DefaultNamespace;

public interface IMemberRepository
{
    void Add(Member member);
    List<Members> GetAll();
    Member GetById(int accountId);
}
