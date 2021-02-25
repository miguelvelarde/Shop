namespace Shop.Web.Data
{    
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;

    public interface IRepository
    {
        void AddProduct(Product p);
        
        Product GetProduct(int id);
        
        IEnumerable<Product> GetProducts();
        
        bool ProductExists(int id);
        
        void RemoveProduct(Product p);
        
        Task<bool> SaveAllAsync();
        
        void UpdateProduct(Product p);
    }
}