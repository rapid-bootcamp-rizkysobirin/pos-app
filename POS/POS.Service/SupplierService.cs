using POS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class SupplierService
    {
        private readonly ApplicationDBContext _context;
        public SupplierService(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<SuppliersEntity> GetSuppliers()
        {
            return _context.supplierEntities.ToList();
        }

        public SuppliersEntity View(int? id)
        {
            var suppplier = _context.supplierEntities.Find();
            return suppplier;
        }

        public void Add(SuppliersEntity supplier)
        {
            _context.supplierEntities.Add(supplier);
            _context.SaveChanges();
        }
        public void Update(SuppliersEntity supplier)
        {
            _context.supplierEntities.Update(supplier);
            _context.SaveChanges();
        }
        public void Delete(int? id)
        {
            var supplier = View(id);
            _context.supplierEntities.Remove(supplier);
            _context.SaveChanges();
        }
    }
}
