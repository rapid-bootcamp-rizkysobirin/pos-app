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

        private OrderDetailModel EntityToModelOrderDetail(OrderDetailsEntity entity)
        {
            OrderDetailModel model = new OrderDetailModel();
            model.Id = entity.Id;
            model.ProductId = entity.ProductId;
            model.UnitPrice = entity.UnitPrice;
            model.Quantity = entity.Quantity;
            model.Discount = entity.Discount;

            return model;
        }

        private OrderModel EntityToModel(OrdersEntity entity)
        {
            OrderModel result = new OrderModel();
            result.Id= entity.Id;
            result.CustomerId= entity.CustomerId;
            result.EmployeeId= entity.EmployeeId;
            result.OrderDate= entity.OrderDate;
            result.RequiredDate= entity.RequiredDate;
            result.ShippedDate= entity.ShippedDate;
            result.ShipperId = entity.ShipperId;
            result.ShipVia= entity.ShipVia;
            result.Freight= entity.Freight;
            result.ShipName= entity.ShipName;
            result.ShipAddress= entity.ShipAddress;
            result.ShipCity= entity.ShipCity;
            result.ShipRegion= entity.ShipRegion;
            result.ShipPostalCode= entity.ShipPostalCode;
            result.ShipCountry= entity.ShipCountry;
            result.OrderDetailsModel = new List<OrderDetailModel>();

            foreach(var item in entity.orderDetailsEntities)
            {
                result.OrderDetailsModel.Add(EntityToModelOrderDetail(item));
            }
            return result;
        }

        private OrderDetailsEntity ModelToEntityOrderDetail(OrderDetailModel model)
        {
            OrderDetailsEntity entity = new OrderDetailsEntity();
            entity.OrderId = model.OrderId;
            entity.ProductId = model.ProductId;
            entity.UnitPrice = model.UnitPrice;
            entity.Quantity = model.Quantity;
            entity.Discount = model.Discount;

            return entity;
        }

        private OrdersEntity ModelToEntity(OrderModel model) 
        {
            OrdersEntity entity = new OrdersEntity();
            entity.CustomerId= model.CustomerId;
            entity.EmployeeId= model.EmployeeId;
            entity.OrderDate= model.OrderDate;
            entity.RequiredDate= model.RequiredDate;
            entity.ShippedDate = model.ShippedDate;
            entity.ShipperId = model.ShipperId;
            entity.ShipVia= model.ShipVia;
            entity.Freight= model.Freight;
            entity.ShipName= model.ShipName;
            entity.ShipAddress= model.ShipAddress;
            entity.ShipCity= model.ShipCity;
            entity.ShipRegion= model.ShipRegion;
            entity.ShipPostalCode= model.ShipPostalCode;
            entity.ShipCountry= model.ShipCountry;

            entity.orderDetailsEntities = new List<OrderDetailsEntity>();
            foreach(var item in model.OrderDetailsModel)
            {
                entity.orderDetailsEntities.Add(ModelToEntityOrderDetail(item));
            }


            return entity;
        }

        public OrderService(ApplicationDBContext context) 
        {
            _context= context;
        }

        private OrderAndDetailRO GetOrderAndDetailRO(OrdersEntity entity)
        {
            var customer = _context.customerEntities.Find(entity.CustomerId);
            var shipper = _context.shipperEntities.Find(entity.ShipperId);

            OrderAndDetailRO orderAndDetail = new OrderAndDetailRO();

            orderAndDetail.Id = entity.Id;
            orderAndDetail.CustomersId = customer.Id;
            orderAndDetail.CustomerName = customer.CustomerName;
            orderAndDetail.OrderDate = entity.OrderDate;
            orderAndDetail.RequiredDate = entity.RequiredDate;
            orderAndDetail.ShippedDate = entity.ShippedDate;
            orderAndDetail.ShipperId = shipper.Id;
            orderAndDetail.ShipperName = shipper.CompanyName;
            orderAndDetail.ShipperPhone = shipper.Phone;
            orderAndDetail.Freight = entity.Freight;
            orderAndDetail.ShipName = entity.ShipName;
            orderAndDetail.ShipAddress = entity.ShipAddress;
            orderAndDetail.ShipCity = entity.ShipCity;
            orderAndDetail.ShipRegion = entity.ShipRegion;
            orderAndDetail.ShipPostalCode = entity.ShipPostalCode;
            orderAndDetail.ShipCountry = entity.ShipCountry;
            orderAndDetail.orderDetails = new List<OrderDetailRO>();
            
            foreach(var item in entity.orderDetailsEntities)
            {
                orderAndDetail.orderDetails.Add(GetDetailOrderRO(item));
            }

            var subTotal = 0.0;
            foreach(var item in orderAndDetail.orderDetails)
            {
                item.SubTotal = item.Quantity * item.UnitPrice * (1 - item.Discount / 100);
                subTotal += item.SubTotal;
            }

            orderAndDetail.Subtotal = subTotal;
            orderAndDetail.Tax = 0.1 * subTotal;
            orderAndDetail.Shipping = 0;

            orderAndDetail.Total = orderAndDetail.Subtotal + orderAndDetail.Tax + orderAndDetail.Shipping;

            return orderAndDetail;

        }

        private OrderDetailRO GetDetailOrderRO(OrderDetailsEntity entity)
        {
            var model = new OrderDetailRO();
            var product = _context.productEntities.Find(entity.ProductId);

            model.Id = entity.Id;
            model.ProductId = product.Id;
            model.ProductName = product.ProductName;
            model.UnitPrice = entity.UnitPrice;
            model.Quantity = entity.Quantity;
            model.Discount = entity.Discount;

            return model;
        }

        public List<OrdersEntity> GetOrders()
        {
            return _context.orderEntities.ToList();
        }

        public OrderModel View(int? id)
        {
            /*var order = _context.orderEntities.Find(id);
            return EntityToModel(order);*/
            var order = _context.orderEntities.Find(id);
            var detail = _context.orderDetailsEntities.Where(x => x.OrderId == id);
            foreach (var item in detail) { }
            return EntityToModel(order);
        }

        public OrderAndDetailRO ViewDetail(int? id)
        {
            var orderEntity = _context.orderEntities.Find(id);
            var detailEntity = _context.orderDetailsEntities.Where(x => x.OrderId == id).ToList();
            orderEntity.orderDetailsEntities = detailEntity;
            var orderResponse = GetOrderAndDetailRO(orderEntity);
            return orderResponse;
        }

        public void Add(OrderModel order)
        {
            /*_context.orderEntities.Add(order);
            _context.SaveChanges();*/

            var data = ModelToEntity(order);
            _context.orderEntities.Add(data);
            foreach (var item in data.orderDetailsEntities)
            {
                item.OrderId = data.Id;
                _context.orderDetailsEntities.Add(item);
            }
            _context.SaveChanges();
        }


        public void Update(OrderModel order)
        {
            /* var entity = _context.orderEntities.Find(order.Id);
             ModelToEntity(order, entity);
             _context.orderEntities.Update(entity);
             _context.SaveChanges();*/

            var entityOrder = _context.orderEntities.Find(order.Id);
            var orderDetailList = _context.orderDetailsEntities.Where(x => x.OrderId == order.Id).ToList();

            var updatedEntity = ModelToEntity(order);

            entityOrder.CustomerId = updatedEntity.CustomerId;
            entityOrder.EmployeeId = updatedEntity.EmployeeId;
            entityOrder.OrderDate = updatedEntity.OrderDate;
            entityOrder.RequiredDate = updatedEntity.RequiredDate;
            entityOrder.ShippedDate = updatedEntity.ShippedDate;
            entityOrder.ShipperId = updatedEntity.ShipperId;
            entityOrder.ShipVia = updatedEntity.ShipVia;
            entityOrder.Freight = updatedEntity.Freight;
            entityOrder.ShipName = updatedEntity.ShipName;
            entityOrder.ShipAddress = updatedEntity.ShipAddress;
            entityOrder.ShipCity = updatedEntity.ShipCity;
            entityOrder.ShipRegion = updatedEntity.ShipRegion;
            entityOrder.ShipPostalCode = updatedEntity.ShipPostalCode;
            entityOrder.ShipCountry = updatedEntity.ShipCountry;
            entityOrder.orderDetailsEntities = updatedEntity.orderDetailsEntities;

            // update order entity
            _context.orderEntities.Update(entityOrder);

            foreach (var newItem in entityOrder.orderDetailsEntities)
            {
                newItem.OrderId = order.Id;
                foreach (var item in orderDetailList)
                {
                    if (newItem.ProductId == item.ProductId)
                    {
                        item.ProductId = newItem.ProductId;
                        item.UnitPrice = newItem.UnitPrice;
                        item.Quantity = newItem.Quantity;
                        item.Discount = newItem.Discount;

                        // update order detail entity
                        _context.orderDetailsEntities.Update(item);
                    }
                }

            }
            // save updated order & order entity
            _context.SaveChanges();


        }

        public void Delete(int? id)
        {
            var order = _context.orderEntities.Find(id);
            _context.orderEntities.Remove(order);

            var detail = _context.orderDetailsEntities.Where(x => x.Id == id);
            foreach (var item in detail)
            {
                _context.orderDetailsEntities.Remove(item);
            }

            _context.SaveChanges();

        }
    }
}
