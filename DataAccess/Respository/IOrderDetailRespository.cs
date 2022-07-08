using BussinessObject.Models;

namespace DataAcess.Respository
{
    public interface IOrderDetailRespository
    {
        List<OrderDetail> GetOrderDetailsList();
        OrderDetail GetOrderDetailByID(int ID);

        List<OrderDetail> GetOrderDetailByProductID(int id);

        void AddNewOrderDetail(OrderDetail o);

        void UpdateOrderDetail(OrderDetail o);

        void RemoveByOrderDetailID(int ID);

    }//IOrderDetailRespository interface end
}//DataAcess.Respository namespace end