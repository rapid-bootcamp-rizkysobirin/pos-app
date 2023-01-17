﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_order")]
    public class OrdersEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }


        [Column("customer_id")]
        public int CustomerId { get; set; }
        public CustomersEntity Customer { get; set; } //buat menghubungkan table

        [Column("employee_id")]
        public int EmployeeId { get; set; }
        public EmployeesEntity Employee { get; set; }


        [Required]
        [Column("order_date")]
        public DateTime OrderDate { get; set; }
        [Required]
        [Column("required_date")]
        public DateTime RequiredDate { get; set; }
        [Required]
        [Column("shipped_date")]
        public DateTime ShippedDate { get; set;}
        [Required]
        [Column("ship_via")]
        public int ShipVia { get; set; }

        [Required]
        [Column("freight")]
        public int Freight { get; set; }
        /*public int ShipVia { get; set; }*/
        [Column("ship_name")]
        public string ShipName { get; set; }
        [Required]
        [Column("ship_address")]
        public string ShipAddress { get; set; }
        
        [Required]
        [Column("ship_city")]
        public string ShipCity { get; set; }
        
        [Required]
        [Column("ship_region")]
        public string ShipRegion { get; set; }

        [Required]
        [Column("ship_postal_code")]
        public string ShipPostalCode { get; set; }

        [Required]
        [Column("ship_country")]
        public string ShipCountry { get; set; }

        public ICollection<OrderDetailsEntity> orderDetailsEntities { get; set; }

        public OrdersEntity(POS.ViewModel.OrderModel model)
        {
            CustomerId = model.CustomerId;
            EmployeeId = model.EmployeeId;
            OrderDate = model.OrderDate;
            RequiredDate = model.RequiredDate;
            ShippedDate = model.ShippedDate;
            ShipVia = model.ShipVia;
            Freight = model.Freight;
            ShipName = model.ShipName;
            ShipAddress = model.ShipAddress;
            ShipCity = model.ShipCity;
            ShipRegion = model.ShipRegion;
            ShipPostalCode = model.ShipPostalCode;
            ShipCountry = model.ShipCountry;


        }

        public OrdersEntity()
        {

        }
    }
}
