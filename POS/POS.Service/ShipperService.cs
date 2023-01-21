using POS.Repository;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class ShipperService
    {
        private readonly ApplicationDBContext _context;
        private ShipperModel EntityToModel (ShipperEntity entity)
        {
            ShipperModel model = new ShipperModel();
            model.Id= entity.Id;
            model.CompanyName= entity.CompanyName;
            model.Phone= entity.Phone;
            return model;
        }

        private void ModelToEntity(ShipperModel model, ShipperEntity entity)
        {
            entity.CompanyName= model.CompanyName;
            entity.Phone= model.Phone;
        }

        public ShipperService(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<ShipperEntity> GetShipper() //get All
        {
            return _context.shipperEntities.ToList();
        }

        public void Add(ShipperEntity shipper)
        {
            _context.shipperEntities.Add(shipper);
            _context.SaveChanges();
        }

        public ShipperModel GetShipper(int? id)
        {
            var shipper = _context.shipperEntities.Find(id);
            return EntityToModel(shipper);
        }

        public ShipperModel Edit(int? id)
        {
            var shipper = _context.shipperEntities.Find(id);
            return EntityToModel(shipper);
        }

        public void Update(ShipperModel model)
        {
            var shipper = _context.shipperEntities.Find(model.Id);
            ModelToEntity(model, shipper);
            _context.shipperEntities.Update(shipper);
            _context.SaveChanges();

        }
        public void Delete(int? id)
        {
            var data = _context.shipperEntities.Find(id);
            Console.WriteLine(data);
            _context.shipperEntities.Remove(data);
            _context.SaveChanges();
        }

    }
}
