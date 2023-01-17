using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_employee")]
    public class EmployeesEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("last_name")]
        public string LastName { get; set; }
        [Required]
        [Column("first_name")]
        public string FirstName { get; set; }
        [Required]
        [Column("title")]
        public string Title { get; set; }
        [Required]
        [Column("title_of_Courtesy")]
        public string TitleOfCourtesy { get; set; }
        [Required]
        [Column("birth_date")]
        public DateTime BirthDate { get; set; }
        [Required]
        [Column("hire_date")]
        public DateTime HireDate { get; set; }
        [Required]
        [Column("address")]
        public string Address { get; set; }
        [Required]
        [Column("city")]
        public string City { get; set; }
        [Required]
        [Column("region")]
        public string Region { get; set; }
        [Required]
        [Column("postal_code")]
        public string PostalCode { get; set; }
        [Required]
        [Column("country")]
        public string Country { get; set; }
        [Required]
        [Column("home_phone")]
        public string HomePhone { get; set; }
        [Required]
        [Column("extension")]
        public string Extension { get; set; }
        [Required]
        [Column("notes")]
        public string Notes { get; set; }
        [Required]
        [Column("report_to")]
        public int ReportTo { get; set; }
        [Required]
        [Column("photo_path")]
        public string PhotoPath { get; set; }

        public ICollection<OrdersEntity> ordersEntities{ get; set; }

        public EmployeesEntity(POS.ViewModel.EmployeeModel model)
        {
            LastName= model.LastName;
            FirstName= model.FirstName;
            Title= model.Title;
            TitleOfCourtesy= model.TitleOfCourtesy;
            BirthDate = model.BirthDate;
            HireDate= model.HireDate;
            Address = model.Address;
            City = model.City;
            Region = model.Region;
            PostalCode = model.PostalCode;
            Country = model.Country;
            HomePhone = model.HomePhone;
            Extension = model.Extension;
            Notes = model.Notes;
            ReportTo= model.ReportTo;
            PhotoPath= model.PhotoPath;

        }
        public EmployeesEntity()
        {

        } 

    }

}
