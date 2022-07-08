using BussinessObject.Models;
namespace DataAcess
{
    public class ProductDAO
    { 
        //Singleton Pattern
        private static ProductDAO instance;
    private static readonly object instanceLock = new object();
    private ProductDAO() { }
    public static ProductDAO Instance
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new ProductDAO();
                }
                return instance;
            }
        }
    }//static ProductDAO end
     //---------------------------------------------------------------------------------
     //Get List of all members
    public List<Product> GetProductsList()
    {
        List<Product> products;

        try
        {
            using FstoreDBContext context = new FstoreDBContext();
                products = context.Products.ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return products;
    }//GetProductsList end
     //-------------------------------------------------------------------------------------
     //Get Product by ID
    public Product GetProductByID(int ID)
    {
        List<Product> productList = GetProductsList();
            //LINQ to Obj
            Product product = productList.SingleOrDefault(obj => obj.ProductId == ID);

        return product;
    }//GetProductByID end
     //-------------------------------------------------------------------------------------
         //-------------------------------------------------------------------------------------
        public List<Product> GetProductByProductName(string name)
    {
        List<Product> productList = GetProductsList();
            List<Product> listResult = new List<Product>();
            //LINQ to Obj
            foreach (Product pro in productList)
            {
                if (pro.ProductName.Contains(name)) listResult.Add(pro);
            }
           

        return listResult;
    }//GetProductListByName end
     //--------------------------------------------------------------------------------------
     //Get Product List by Price
        public List<Product> GetProductByUnitPrice(decimal price)
    {
        List<Product> result = new List<Product>();
        List<Product> ProductsList = GetProductsList();
        for (int i = 0; i <= ProductsList.Count; i++)
        {
            if (ProductsList[i].UnitPrice == price )
            {
                result.Add(ProductsList[i]);
            }
        }

        return result;
        }//GetProductByPriceend
         //--------------------------------------------------------------------------------------
         //Get Product List by UnitInStock
        public List<Product> GetProductByUnitInStock(int u)
        {
            List<Product> result = new List<Product>();
            List<Product> ProductsList = GetProductsList();
            for (int i = 0; i <= ProductsList.Count; i++)
            {
                if (ProductsList[i].UnitInStock == u)
                {
                    result.Add(ProductsList[i]);
                }
            }

            return result;
        }//GetProductByUnitInStockend
         //--------------------------------------------------------------------------------------
         //Add a new Product
        public void AddNewProduct(Product product)
    {
        try
        {
            using FstoreDBContext context = new FstoreDBContext();
                context.Products.Add(product);
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        }//AddNewProduct end
         //--------------------------------------------------------------------------------
         //Update a Product
        public void UpdateProduct(Product product)
    {
        try
        {
            using FstoreDBContext context = new FstoreDBContext();
            context.Entry<Product>(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        }//UpdateProduct end
         //----------------------------------------------------------------------------------
         //Remove a Product by ID
        public void RemoveByID(int productID)
    {
        try
        {
            using FstoreDBContext context = new FstoreDBContext();
            var product = context.Products.SingleOrDefault(m => m.ProductId == productID);
            context.Products.Remove(product);
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }//RemoveByID End
     //------------------------------------------------------------------------------------
    }//ProductDAO class end

}