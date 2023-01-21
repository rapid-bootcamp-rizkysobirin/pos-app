using Microsoft.EntityFrameworkCore;
using POS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<ProductsEntity> productEntities => Set<ProductsEntity>();
        public DbSet<CategoriesEntity> categoryEntities => Set<CategoriesEntity>();
        public DbSet<EmployeesEntity> employeeEntities => Set<EmployeesEntity>();
        public DbSet<CustomersEntity> customerEntities => Set<CustomersEntity>();
        public DbSet<SuppliersEntity> supplierEntities => Set<SuppliersEntity>();
        public DbSet<OrdersEntity> orderEntities => Set<OrdersEntity>();
        public DbSet<OrderDetailsEntity> orderDetailsEntities => Set<OrderDetailsEntity>(); 
        public DbSet<ShipperEntity> shipperEntities => Set<ShipperEntity>();

    }
}
