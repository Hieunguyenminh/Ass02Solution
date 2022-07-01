using BussinessObject.Models;
namespace DataAcess
{
    public class OrderDAO
    {
        //Singleton Pattern
        private static OrderDAO instance;
        private static readonly object instanceLock = new object();
        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }//static OrderDAO end
         //---------------------------------------------------------------------------------
         //Get List of all order
        public List<Order> GetOrdersList()
        {
            List<Order> orders;

            try
            {
                using FstoreDBContext context = new FstoreDBContext();
                orders = context.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return orders;
        }//GetOrdersList end
         //-------------------------------------------------------------------------------------
         //Get Order by ID
        public Order GetOrderByID(int ID)
        {
            List<Order> List = GetOrdersList();
            //LINQ to Obj
            Order order = List.SingleOrDefault(obj => obj.OrderId == ID);

            return order;
        }//GetOrderByID end
         //-------------------------------------------------------------------------------------

        //Get Order List by MemberID
        public List<Order> GetOrderByMemberID(int id)
        {
            List<Order> result = new List<Order>();
            List<Order> OrdersList = GetOrdersList();
            for (int i = 0; i <= OrdersList.Count; i++)
            {
                if (OrdersList[i].MemberId == id)
                {
                    result.Add(OrdersList[i]);
                }
            }

            return result;
        }//GetOrderListByMemberIDend
         //--------------------------------------------------------------------------------------

        //Add a new Order
        public void AddNewOrder(Order o)
        {
            try
            {
                using FstoreDBContext context = new FstoreDBContext();
                context.Orders.Add(o);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }//AddNewOrder end
         //--------------------------------------------------------------------------------
         //Update a Order
        public void UpdateOrder(Order o)
        {
            try
            {
                using FstoreDBContext context = new FstoreDBContext();
                context.Entry<Order>(o).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }//UpdateOrder end
         //----------------------------------------------------------------------------------
         //Remove a Order by OrderID
        public void RemoveByOrderID(int ID)
        {
            try
            {
                using FstoreDBContext context = new FstoreDBContext();
                var o = context.Orders.SingleOrDefault(m => m.OrderId == ID);
                context.Orders.Remove(o);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }//RemoveByID End
         //------------------------------------------------------------------------------------
    }//OrderDAO class end

}