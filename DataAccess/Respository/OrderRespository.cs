using BussinessObject.Models;

namespace DataAcess.Respository
{
    public class OrderRespository : IOrderRespository
    {
        public IEnumerable<Order> GetOrders() => OrderDAO.Instance.GetOrdersList();
        public IEnumerable<Order> GetOrderListByMemberID(int id) => OrderDAO.Instance.GetOrderByMemberID(id);
        /* public  List<Order> GetOrderByMemberID(int id) => OrderDAO.Instance.GetOrderByMemberID(id);*/


        public Order GetOrderByID(int ID)=> OrderDAO.Instance.GetOrderByID(ID);
        public void InsertOrder(Order order)=> OrderDAO.Instance.AddNewOrder(order);
        public void UpdateOrder(Order order)=> OrderDAO.Instance.UpdateOrder(order);
        /*public void RemoveByOrderID(int ID)=> OrderDAO.Instance.RemoveByOrderID(ID);*/
        public void RemoveOrder(int OrderID) => OrderDAO.Instance.RemoveByOrderID(OrderID);
        public List<Order> GetOrderByOrderdDate(DateTime dateTime1, DateTime dateTime2) => OrderDAO.Instance.Filter(dateTime1, dateTime2);
    }
}//DataAcess.Respository namespace end
