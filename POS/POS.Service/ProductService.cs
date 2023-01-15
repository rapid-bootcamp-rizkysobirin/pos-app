using POS.Repository;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.ViewModel;
using POS.ViewModel.Response;

namespace POS.S
{
    public class ProductService
    {
        private readonly ApplicationDBContext _context;
        
        private ProductModel EntityToModel(ProductsEntity entity)
        {
            ProductModel result = new ProductModel();
            result.Id = entity.Id;
            result.ProductName= entity.ProductName;
            result.SupplierId= entity.SupplierId;
            result.CategoryId= entity.CategoryId;
            result.Quantity= entity.Quantity;
            result.UnitPrice= entity.UnitPrice;
            result.UnitInOrder= entity.UnitInOrder;
            result.UnitInStock= entity.UnitInStock;
            result.ReorderLevel= entity.ReorderLevel;
            result.Discontinued= entity.Discontinued;

            return result;
        }

        private void ModelToEntity(ProductModel model, ProductsEntity entity)
        {
            entity.ProductName= model.ProductName;
            entity.SupplierId= model.SupplierId;
            entity.CategoryId= model.CategoryId;
            entity.Quantity= model.Quantity;
            entity.UnitPrice= model.UnitPrice;
            entity.UnitInOrder= model.UnitInOrder;
            entity.UnitInStock= model.UnitInStock;
            entity.ReorderLevel= model.ReorderLevel;
            entity.Discontinued= model.Discontinued;
        }

        private ProductResponse ResponseEntityToModel(ProductsEntity entity)
        {
            ProductResponse result = new ProductResponse();
            var category= _context.categoryEntities.Find(entity.CategoryId);
            var supplier= _context.supplierEntities.Find(entity.SupplierId);

            result.Id = entity.Id;
            result.CategoryName = category.CategoryName;
            result.ProductName= entity.ProductName;
            result.CompanyName = supplier.CompanyName;
            result.Quantity= entity.Quantity;
            result.UnitPrice= entity.UnitPrice;
            result.UnitInOrder= entity.UnitInOrder;
            result.UnitInStock = entity.UnitInStock;
            result.ReorderLevel= entity.ReorderLevel;
            result.Discontinued= entity.Discontinued;

            return result;
        }

        private ProductDetailResponse ResponseEntityToModelDetails(ProductsEntity entity)
        {
            ProductDetailResponse result = new ProductDetailResponse();
            var category = _context.categoryEntities.Find(entity.CategoryId);
            var supplier = _context.supplierEntities.Find(entity.SupplierId) ;

            result.Id = entity.Id;
            result.ProductName = entity.ProductName;

            result.CompanyName = supplier.CompanyName;
            result.ContactName = supplier.ContactName;
            result.ContactTitle = supplier.ContactTitle;
            result.Phone = supplier.Phone;
            result.HomePage = supplier.HomePage;
            result.CategoryName = category.CategoryName;
            result.Quantity = entity.Quantity;
            result.UnitPrice = entity.UnitPrice;
            result.UnitInStock = entity.UnitInStock;
            result.UnitInOrder = entity.UnitInOrder;
            result.ReorderLevel = entity.ReorderLevel;
            result.Discontinued = entity.Discontinued;

            return result;
        }

        public ProductService(ApplicationDBContext context)
        {
            _context = context;
        }

        /*public List<ProductsEntity> GetProducts()
        {
            List<ProductsEntity> products = _context.productEntities.ToList();
            List<ProductResponse> response = new List<ProductResponse>();
            for(int i; i<products.Count; i++)
            {
                response.Add(ResponseEntityToModel(products[i]));
            }
            return response;
        }*/

        public List<ProductResponse> GetProducts()
        {
            List<ProductsEntity> products = _context.productEntities.ToList();
            List<ProductResponse> response = new List<ProductResponse>();
            for (int i = 0; i < products.Count; i++)
            {
                response.Add(ResponseEntityToModel(products[i]));
            }
            return response;
        }

        public ProductModel View(int? id)
        {
            var product = _context.productEntities.Find(id);
            return EntityToModel(product);
        }

        public ProductDetailResponse ViewProductResponse(int? id)
        {
            var product=_context.productEntities.Find(id);
            return ResponseEntityToModelDetails(product);
        }

        public void Add(ProductsEntity product)
        {
            _context.productEntities.Add(product);
            _context.SaveChanges();
        }

        public void Update(ProductModel product)
        {
            var entity = _context.productEntities.Find(product.Id);
            ModelToEntity(product, entity);
            _context.productEntities.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var product = _context.productEntities.Find(id);
            _context.productEntities.Remove(product);
            _context.SaveChanges();
        }
    }
}
