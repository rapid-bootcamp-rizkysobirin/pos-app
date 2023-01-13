using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int UnitPrice { get; set; }

        [Required]
        public int UnitInStock { get; set; }

        [Required]
        public int UnitInOrder { get; set; }

        [Required]
        public int ReorderLevel { get; set; }

        [Required]
        public bool Discontinued { get; set; }
    }
}
