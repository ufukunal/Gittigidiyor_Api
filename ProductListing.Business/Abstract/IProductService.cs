using ProductListining.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductListining.Business.Abstract
{
    public interface IProductService
    {
        Product GetById(int productId);
        List<Product> GetAll();
        List<Product> GetProductsByCategory(int categoryId);
        List<Product> GetProductByProductName(string productName);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
