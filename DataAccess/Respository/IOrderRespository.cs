using BussinessObject.Models;

namespace DataAcess.Respository
{
    public interface IOrderRespository
    {
        /*IEnumerable<Order> GetOrdersList();
        List<Order> GetOrderByMemberID(int id);*/
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetOrderListByMemberID(int id);
        Order GetOrderByID(int ID);     
        void InsertOrder(Order order);
        void UpdateOrder(Order order);
        /*void RemoveByOrderID(int ID);*/
        void RemoveOrder(int OrderID);
        List<Order> GetOrderByOrderdDate(DateTime dateTime1, DateTime dateTime2);
    }//IOrderRespository interface end
}//DataAcess.Respository namespace end