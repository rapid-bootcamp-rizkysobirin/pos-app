using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_product")]
    public class ProductsEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("product_name")]
        public string ProductName { get; set; }


        [Column("supplier_id")]
        public int SupplierId { get; set; }
        public SuppliersEntity Supplier { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }
        public CategoriesEntity Category { get; set; }

        [Required]
        [Column("quantity")]
        public int Quantity { get; set; }
        [Required]
        [Column("unit_price")]
        public int UnitPrice { get; set; }
        [Required]
        [Column("unit_in_stock")]
        public int UnitInStock { get; set; }
        [Required]
        [Column("unit_in_order")]
        public int UnitInOrder { get; set; }
        [Required]
        [Column("reorder_level")]
        public int ReorderLevel { get; set; }
        [Required]
        [Column("discontinued")]
        public bool Discontinued { get; set; }
        public ICollection<OrderDetailsEntity> orderDetailsEntities { get; set; }

        public ProductsEntity(POS.ViewModel.ProductModel model) 
        {
            ProductName = model.ProductName;
            SupplierId = model.SupplierId;
            CategoryId = model.CategoryId;
            UnitPrice = model.UnitPrice;
            UnitInStock = model.UnitInStock;
            UnitInOrder = model.UnitInOrder;
            ReorderLevel = model.ReorderLevel;
            Discontinued = model.Discontinued;
        }
        public ProductsEntity()
        {

        }
    }
}
