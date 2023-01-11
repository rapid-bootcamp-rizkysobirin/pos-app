using POS.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DataContext
{
    [Table("tbl_categories")]
    public class Categories
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("category_name")]
        public string CategoryName { get; set; }
        [Column("description")]
        public string Description { get; set; }

        public ICollection<Products> Product { get; set; }

    }
}