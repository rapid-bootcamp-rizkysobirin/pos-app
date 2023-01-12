using POS.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_categorie")]
    public class CategoriesEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("category_name")]
        public string CategoryName { get; set; }
        [Column("description")]
        public string Description { get; set; }

        public ICollection<ProductsEntity> productsEntities { get; set; }

    }
}