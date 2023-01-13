using POS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class CustomerService
    {
        private readonly ApplicationDBContext _context;
        public CustomerService(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<CustomersEntity> GetCustomers()
        {
            return _context.customerEntities.ToList();
        }

        public CustomersEntity View(int? id)
        {
            var customer = _context.customerEntities.Find(id);
            return customer;
        }

        public void Add(CustomersEntity customer)
        {
            _context.customerEntities.Add(customer);
            _context.SaveChanges();
        }

        public void Update(CustomersEntity customer)
        {
            _context.customerEntities.Update(customer);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var customer = View(id);
            _context.customerEntities.Remove(customer);
            _context.SaveChanges();
        }
    }
}
