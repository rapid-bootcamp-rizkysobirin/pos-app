using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class OrderDetailModel
    {
        public int Id { get; set; }

        [Required]
        public int OrdersId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int UnitPrice { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int Discount { get; set; }
    }
}
