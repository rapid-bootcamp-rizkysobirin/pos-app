using Microsoft.EntityFrameworkCore;
using POS.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    public class PosAppContext : DbContext
    {
        public PosAppContext(DbContextOptions<PosAppContext> options) : base(options)
        {

        }

        public DbSet<Products> ProductEntities => Set<Products>();
        public DbSet<Categories> CategoryEntities => Set<Categories>();
        public DbSet<Employees> EmployeeEntities => Set<Employees>();
        public DbSet<Customers> CustomerEntities => Set<Customers>();
        public DbSet<Suppliers> SupplierEntities => Set<Suppliers>();
        public DbSet<Orders> OrderEntities => Set<Orders>();

    }
}
