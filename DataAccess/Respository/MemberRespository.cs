using BussinessObject.Models;

namespace DataAcess.Respository
{
    public class MemberRespository : IMemberRespository
    {
        public void DeleteMember(int memberID) => MemberDAO.Instance.RemoveByID(memberID);

        public Member GetMemberByCompanyName(string companyName) => MemberDAO.Instance.GetMemberByCompanyName(companyName);

        public Member GetMemberByID(int memberID) => MemberDAO.Instance.GetMemberByID(memberID);

        public IEnumerable<Member> GetMembers() => MemberDAO.Instance.GetMembersList();

        public List<Member> GetMembersByCityOrCountry(string city, string country) => MemberDAO.Instance.GetMemberByCityOrCountry(city, country);

        public IEnumerable<Member> GetMembersByIDList(int memberID) => MemberDAO.Instance.GetMemberByIDList(memberID);

        public void InsertMember(Member member) => MemberDAO.Instance.AddNewMenber(member);

        public void UpdateMember(Member member) => MemberDAO.Instance.UpdateMember(member);
    }
}//DataAcess.Respository namespace end