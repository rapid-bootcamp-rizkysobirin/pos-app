using POS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.ViewModel;

namespace POS.Service
{
    public class CustomerService
    {
        private readonly ApplicationDBContext _context;

        public CustomerModel EntityToModel(CustomersEntity entity)
        {
            CustomerModel result = new CustomerModel();
            result.Id = entity.Id;
            result.CompanyName= entity.CompanyName;
            result.ContactName=entity.ContactName;
            result.Address = entity.Address;
            result.City = entity.City;
            result.Region = entity.Region;
            result.PostalCode = entity.PostalCode;
            result.Country = entity.Country;
            result.Phone = entity.Phone;
            result.Fax = entity.Fax;

            return result;
        }

        public void ModelToEntity(CustomerModel model, CustomersEntity entity)
        {
            entity.CompanyName= model.CompanyName;
            entity.ContactName= model.ContactName;
            entity.ContactTitle= model.ContactTitle;
            entity.Address= model.Address;
            entity.City= model.City;
            entity.Region= model.Region;
            entity.PostalCode= model.PostalCode;
            entity.Country= model.Country;
            entity.Phone= model.Phone;
            entity.Fax= model.Fax;
        }


        public CustomerService(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<CustomersEntity> GetCustomers()
        {
            return _context.customerEntities.ToList();
        }

        public CustomerModel View(int? id)
        {
            var customer = _context.customerEntities.Find(id);
            return EntityToModel(customer);
        }

        public void Add(CustomersEntity customer)
        {
            _context.customerEntities.Add(customer);
            _context.SaveChanges();
        }

        public void Update(CustomerModel customer)//entity->tanpa validasi, model dg validasi
        {
            //tanpa validasi
            /*_context.customerEntities.Update(customer);
            _context.SaveChanges();*/

            //dg validasi
            var entity = _context.customerEntities.Find(customer.Id);
            ModelToEntity(customer, entity);
            _context.customerEntities.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var customer = _context.customerEntities.Find(id);
            _context.customerEntities.Remove(customer);
            _context.SaveChanges();
        }
    }
}
