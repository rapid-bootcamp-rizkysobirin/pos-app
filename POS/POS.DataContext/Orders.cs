﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_orders")]
    public class Orders
    {
        [Key]

        [Column("id")]
        public int Id { get; set; }
        [Column("customer_id")]
        public int CustomerId { get; set; }
        public Customers Customer { get; set; } //buat menghubungkan table

        [Column("employee_id")]
        public int EmployeeId { get; set; }
        public Employees Employee { get; set; }

        [Column("order_date")]
        public DateTime OrderDate { get; set; }
        [Column("required_date")]
        public DateTime RequiredDate { get; set; }
        [Column("shipped_date")]
        public DateTime ShippedDate { get; set;}
        [Column("freight")]
        public int Freight { get; set; }
        /*public int ShipVia { get; set; }*/
        [Column("ship_name")]
        public string Shipname { get; set; }
        [Column("ship_address")]
        public string ShipAddress { get; set; }
        [Column("ship_city")]
        public string ShipCity { get; set; }
    }
}
