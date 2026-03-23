namespace DefaultNamespace;

public class MemberRepository
{
    //member list
    private List<Member> _members = new List<Member>();

    //adds member
    public void Add(Member member)
    {
        _members.Add(member);
    }

    //returns all members
    public List<Member> GetAll()
    {
        return _members;
    }

    //searches for members by matching account ID
    public Member GetById(int accountId)
    {
        return _members.Find(m => m.AccountId == accountId);
    }
}
