

using BussinessObject.Models;

namespace DataAcess
{
    public class MemberDAO
    {
        //Singleton Pattern
        private static MemberDAO instance;
        private static readonly object instanceLock = new object();
        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }//static MemberDAO end
        //---------------------------------------------------------------------------------
        //Get List of all members
        public List<Member> GetMembersList()
        {
            List<Member> members;

            try
            {
                using FstoreDBContext context = new FstoreDBContext();
                members = context.Members.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return members;
        }//GetMembersList end
        //-------------------------------------------------------------------------------------
        //Get Member by ID
        public Member GetMemberByID(int memberID)
        {
            List<Member> memberList = GetMembersList();
            //LINQ to Obj
            Member member = memberList.SingleOrDefault(obj => obj.MemberId == memberID);

            return member;
        }//GetMemberByID end
        //-------------------------------------------------------------------------------------
        //Get Member by ID List
        public List<Member> GetMemberByIDList(int memberID)
        {
            List<Member> MembersList = GetMembersList();
            //LINQ to Obj
            Member member = MembersList.SingleOrDefault(obj => obj.MemberId == memberID);
            MembersList.Clear();
            MembersList.Add(member);

            return MembersList;
        }//GetMemberByIDList end
        //-------------------------------------------------------------------------------------
        public Member GetMemberByCompanyName(string companyName)
        {
            List<Member> memberList = GetMembersList();
            //LINQ to Obj
            Member member = memberList.SingleOrDefault(obj => obj.CompanyName == companyName);

            return member;
        }//GetMemberByName end
        //--------------------------------------------------------------------------------------
        //Get Member List by City and Country
        public List<Member> GetMemberByCityOrCountry(string city, string country)
        {
            List<Member> result = new List<Member>();
            List<Member> MembersList = GetMembersList();
            for (int i = 0; i < MembersList.Count; i++)
            {
                if (MembersList[i].City == city || MembersList[i].Country == country)
                {
                    result.Add(MembersList[i]);
                }
            }

            return result;
        }//GetMemberByCityAndCountry end
        //--------------------------------------------------------------------------------------
        //Add a new member
        public void AddNewMenber(Member member)
        {
            try
            {
                using FstoreDBContext context = new FstoreDBContext();
                context.Members.Add(member);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }//AddNewMenber end
        //--------------------------------------------------------------------------------
        //Update a member
        public void UpdateMember(Member member)
        {
            try
            {
                using FstoreDBContext context = new FstoreDBContext();
                context.Entry<Member>(member).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }//UpdateMember end
        //----------------------------------------------------------------------------------
        //Remove a member by ID
        public void RemoveByID(int memberID)
        {
            try
            {
                using FstoreDBContext context = new FstoreDBContext();
                var member = context.Members.SingleOrDefault(m => m.MemberId == memberID);
                context.Members.Remove(member);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }//RemoveByID End
        //------------------------------------------------------------------------------------
    }//MemberDAO class end
}