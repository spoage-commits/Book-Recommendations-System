namespace DefaultNamespace;

public class MemberRepository
{
    private List<Member> _members = new List<Member>();

    public void Add(Member member)
    {
        _members.Add(member);
    }

    public List<Members> GetAll() 
    {
        return _members; 
    }

    public Member GetById(int accountId)
    {
        return _members.Find(m => m.AccountId == accountId);
    }
        
}
