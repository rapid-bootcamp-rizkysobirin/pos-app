using POS.Repository;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class OrderService
    {
        private readonly ApplicationDBContext _context;

        private OrderModel EntityToModel(OrdersEntity entity)
        {
            OrderModel result = new OrderModel();
            result.Id= entity.Id;
            result.CustomerId= entity.CustomerId;
            result.EmployeeId= entity.EmployeeId;
            result.OrderDate= entity.OrderDate;
            result.RequiredDate= entity.RequiredDate;
            result.ShippedDate= entity.ShippedDate;
            result.ShipVia= entity.ShipVia;
            result.Freight= entity.Freight;
            result.ShipName= entity.ShipName;
            result.ShipAddress= entity.ShipAddress;
            result.ShipCity= entity.ShipCity;
            result.ShipRegion= entity.ShipRegion;
            result.ShipPostalCode= entity.ShipPostalCode;
            result.ShipCountry= entity.ShipCountry;
            return result;
        }

        private void ModelToEntity(OrderModel model, OrdersEntity entity) 
        {
            entity.CustomerId= model.CustomerId;
            entity.EmployeeId= model.EmployeeId;
            entity.OrderDate= model.OrderDate;
            entity.RequiredDate= model.RequiredDate;
            entity.ShippedDate = model.ShippedDate;
            entity.ShipVia= model.ShipVia;
            entity.Freight= model.Freight;
            entity.ShipName= model.ShipName;
            entity.ShipAddress= model.ShipAddress;
            entity.ShipCity= model.ShipCity;
            entity.ShipRegion= model.ShipRegion;
            entity.ShipPostalCode= model.ShipPostalCode;
            entity.ShipCountry= model.ShipCountry;
        
        }

        public OrderService(ApplicationDBContext context) 
        {
            _context= context;
        }

        public List<OrdersEntity> GetOrders()
        {
            return _context.orderEntities.ToList();
        }

        public OrderModel View(int? id)
        {
            var order = _context.orderEntities.Find(id);
            return EntityToModel(order);
        }

        public void Add(OrdersEntity order)
        {
            _context.orderEntities.Add(order);
            _context.SaveChanges();
        }
        public void Update(OrderModel order)
        {
            var entity = _context.orderEntities.Find(order.Id);
            ModelToEntity(order, entity);
            _context.orderEntities.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var order = _context.orderEntities.Find(id);
            _context.orderEntities.Remove(order);
            _context.SaveChanges();
        }
    }
}
