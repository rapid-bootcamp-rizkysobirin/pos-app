using POS.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.ViewModel;

namespace POS.Repository
{
    [Table("tbl_category")]
    public class CategoriesEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("category_name")]
        public string CategoryName { get; set; }
        [Required]
        [Column("description")]
        public string Description { get; set; }

        public ICollection<ProductsEntity> productsEntities { get; set; }

        public CategoriesEntity(POS.ViewModel.CategoryModel model)
        {
            CategoryName = model.CategoryName;
            Description = model.Description;
        }
        public CategoriesEntity()
        {

        }
    }
}