using BussinessObject.Models;

namespace DataAcess.Respository
{
    public interface IMemberRespository
    {
        IEnumerable<Member> GetMembers();
        IEnumerable<Member> GetMembersByIDList(int memberID);
        Member GetMemberByID(int memberID);
        Member GetMemberByCompanyName(string companyName);
        List<Member> GetMembersByCityAndCountry(string city, string country);
        void InsertMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(int memberID);
    }//IMemberRespository interface end
}//DataAcess.Respository namespace end