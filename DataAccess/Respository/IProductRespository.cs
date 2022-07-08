using BussinessObject.Models;

namespace DataAcess.Respository
{
    public interface IProductRespository
    {
        IEnumerable<Product> GetProductsList();
        List<Product> GetProductsByName(string name);
        Product GetProductByID(int productID);

        List<Product> GetProductsByUnitPrice(decimal price);
        List<Product> GetProductsByUnitInStock(int i);
      
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int ID);
    }//IProductRespository interface end
}//DataAcess.Respository namespace end