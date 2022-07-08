using BussinessObject.Models;

namespace DataAcess.Respository
{
    public class OrderDetailRespoitory : IOrderDetailRespository
    {
        public  List<OrderDetail> GetOrderDetailsList()=> OrderDetailDAO.Instance.GetOrderDetailsList();
        public OrderDetail GetOrderDetailByID(int ID) => OrderDetailDAO.Instance.GetOrderDetailByID(ID);

        public List<OrderDetail> GetOrderDetailByProductID(int id) => OrderDetailDAO.Instance.GetOrderDetailByProductID(id);

        public void AddNewOrderDetail(OrderDetail o) => OrderDetailDAO.Instance.AddNewOrderDetail(o);

        public void UpdateOrderDetail(OrderDetail o) => OrderDetailDAO.Instance.UpdateOrderDetail(o);

        public void RemoveByOrderDetailID(int ID) => OrderDetailDAO.Instance.RemoveByOrderDetailID(ID);

    }
}//DataAcess.Respository namespace end
