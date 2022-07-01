using BussinessObject.Models;

namespace DataAcess.Respository
{
    public class OrderRespoitory : IOrderRespository
    {
        public IEnumerable<Order> GetOrdersList() => OrderDAO.Instance.GetOrdersList();
      public  List<Order> GetOrderByMemberID(int id) => OrderDAO.Instance.GetOrderByMemberID(id);
       public Order GetOrderByID(int ID)=> OrderDAO.Instance.GetOrderByID(ID);


       public void InsertOrder(Order order)=> OrderDAO.Instance.AddNewOrder(order);
        public void UpdateOrder(Order order)=> OrderDAO.Instance.UpdateOrder(order);
        public void RemoveByOrderID(int ID)=> OrderDAO.Instance.RemoveByOrderID(ID);
    }
}//DataAcess.Respository namespace end
