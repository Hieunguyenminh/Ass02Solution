using BussinessObject.Models;

namespace DataAcess.Respository
{
    public class ProductRespository : IProductRespository
    {
        public void DeleteProduct(int id) => ProductDAO.Instance.RemoveByID(id);

        public List<Product> GetProductsByName(string name) => ProductDAO.Instance.GetProductByProductName(name);
        public Product GetProductByID(int ID) => ProductDAO.Instance.GetProductByID(ID);

        public IEnumerable<Product> GetProductsList() =>ProductDAO.Instance.GetProductsList();

        public List<Product> GetProductsByUnitPrice(decimal price) => ProductDAO.Instance.GetProductByUnitPrice(price);
        public List<Product> GetProductsByUnitInStock(int i) => ProductDAO.Instance.GetProductByUnitInStock(i);

        public void InsertProduct(Product product) => ProductDAO.Instance.AddNewProduct(product);

        public void UpdateProduct(Product product) => ProductDAO.Instance.UpdateProduct(product);
    }
}//DataAcess.Respository namespace end
