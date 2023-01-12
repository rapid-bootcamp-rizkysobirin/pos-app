using POS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class ProductService
    {
        private readonly ApplicationDBContext _context;
        public ProductService(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<ProductsEntity> GetProducts()
        {
            return _context.productEntities.ToList();
        }

        public ProductsEntity View(int? id)
        {
            var product = _context.productEntities.Find(id);
            return product;
        }

        public void Add(ProductsEntity product)
        {
            _context.productEntities.Add(product);
            _context.SaveChanges();
        }

        public void Update(ProductsEntity product)
        {
            _context.productEntities.Update(product);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var product = View(id);
            _context.productEntities.Remove(product);
            _context.SaveChanges();
        }
    }
}
