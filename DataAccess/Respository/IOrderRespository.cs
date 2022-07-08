using BussinessObject.Models;

namespace DataAcess.Respository
{
    public interface IOrderRespository
    {
        IEnumerable<Order> GetOrdersList();
        List<Order> GetOrderByMemberID(int id);
        Order GetOrderByID(int ID);

       
        void InsertOrder(Order order);
        void UpdateOrder(Order order);
        void RemoveByOrderID(int ID);
    }//IOrderRespository interface end
}//DataAcess.Respository namespace end