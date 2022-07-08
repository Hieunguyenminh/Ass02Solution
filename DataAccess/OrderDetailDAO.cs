using BussinessObject.Models;
namespace DataAcess
{
    public class OrderDetailDAO
    {
        //Singleton Pattern
        private static OrderDetailDAO instance;
        private static readonly object instanceLock = new object();
        private OrderDetailDAO() { }
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }//static OrderDetailDAO end
         //---------------------------------------------------------------------------------
         //Get List of all Detail
        public List<OrderDetail> GetOrderDetailsList()
        {
            List<OrderDetail> orders;

            try
            {
                using FstoreDBContext context = new FstoreDBContext();
                orders = context.OrderDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return orders;
        }//GetOrderDetailsList end
         //-------------------------------------------------------------------------------------
         //Get OrderDetail by ID
        public OrderDetail GetOrderDetailByID(int ID)
        {
            List<OrderDetail> List = GetOrderDetailsList();
            //LINQ to Obj
            OrderDetail orderDetail = List.SingleOrDefault(obj => obj.OrderId == ID);

            return orderDetail;
        }//GetOrderDetailByID end
         //-------------------------------------------------------------------------------------

        //Get Order Detail List by ProductID
        public List<OrderDetail> GetOrderDetailByProductID(int id)
        {
            List<OrderDetail> result = new List<OrderDetail>();
            List<OrderDetail> OrderDetailsList = GetOrderDetailsList();
            for (int i = 0; i <= OrderDetailsList.Count; i++)
            {
                if (OrderDetailsList[i].ProductId == id)
                {
                    result.Add(OrderDetailsList[i]);
                }
            }

            return result;
        }//GetOrderDetailListByProductID end
         //--------------------------------------------------------------------------------------

        //Add a new OrderDetail
        public void AddNewOrderDetail(OrderDetail o)
        {
            try
            {
                using FstoreDBContext context = new FstoreDBContext();
                context.OrderDetails.Add(o);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }//AddNewOrderDetail end
         //--------------------------------------------------------------------------------
         //Update a OrderDetail
        public void UpdateOrderDetail(OrderDetail o)
        {
            try
            {
                using FstoreDBContext context = new FstoreDBContext();
                context.Entry<OrderDetail>(o).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }//UpdateOrderDetail end
         //----------------------------------------------------------------------------------
         //Remove a OrderDetail by OrderID
        public void RemoveByOrderDetailID(int ID)
        {
            try
            {
                using FstoreDBContext context = new FstoreDBContext();
                var o = context.OrderDetails.SingleOrDefault(m => m.OrderId == ID);
                context.OrderDetails.Remove(o);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }//RemoveByID End
         //------------------------------------------------------------------------------------
    }//OrderDetailDAO class end

}