using POS.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_products")]
    public class Products
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("product_name")]
        public string ProductName { get; set; }


        [Column("supplier_id")]
        public int SupplierId { get; set; }
        public Suppliers Supplier { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }
        public Categories Categories { get; set; }


        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("unit_ptice")]
        public double UnitPrice { get; set; }
        [Column("uni_in_stock")]
        public int UnitInStock { get; set; }
        [Column("uni_in_order")]
        public int UnitInOrder { get; set; }
        [Column("reorder_level")]
        public int ReorderLevel { get; set; }
        [Column("discontinued")]
        public bool Discontinued { get; set; }
        public ICollection<OrderDetails> OrderDetail { get; set; }
    }
}
