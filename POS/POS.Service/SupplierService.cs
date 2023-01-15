using POS.Repository;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.ViewModel;

namespace POS.Service
{
    public class SupplierService
    {
        private readonly ApplicationDBContext _context;

        private SupplierModel EntityToModel(SuppliersEntity entity)
        {
            SupplierModel result = new SupplierModel();
            result.Id= entity.Id;
            result.CompanyName= entity.CompanyName;
            result.ContactName= entity.ContactName;
            result.ContactTitle= entity.ContactTitle;
            result.Address= entity.Address;
            result.City= entity.City;
            result.Region= entity.Region;
            result.PostalCode= entity.PostalCode;
            result.Country= entity.Country;
            result.Phone= entity.Phone;
            result.Fax= entity.Fax;
            result.HomePage= entity.HomePage;

            return result;
        }


        private void ModelToEntity(SupplierModel model, SuppliersEntity entity)
        {
            entity.CompanyName= model.CompanyName;
            entity.ContactName=model.ContactName;
            entity.ContactTitle= model.ContactTitle;
            entity.Address= model.Address;
            entity.City= model.City;
            entity.Region= model.Region;
            entity.PostalCode= model.PostalCode;
            entity.Country= model.Country;
            entity.Phone= model.Phone;
            entity.Fax= model.Fax;
            entity.HomePage= model.HomePage;
        }
        public SupplierService(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<SuppliersEntity> GetSuppliers()
        {
            return _context.supplierEntities.ToList();
        }

        public SupplierModel View(int? id)
        {
            var supplier = _context.supplierEntities.Find(id);
            return EntityToModel(supplier);
        }

        public void Add(SuppliersEntity supplier)
        {
            _context.supplierEntities.Add(supplier);
            _context.SaveChanges();
        }
        public void Update(SupplierModel supplier)
        {
            var entity = _context.supplierEntities.Find(supplier.Id);
            ModelToEntity(supplier, entity);
            _context.supplierEntities.Update(entity);
            _context.SaveChanges();
        }
        public void Delete(int? Id)
        {
            var supplier = _context.supplierEntities.Find(Id);
            _context.supplierEntities.Remove(supplier);
            _context.SaveChanges();
        }
    }
}
