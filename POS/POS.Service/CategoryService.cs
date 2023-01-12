using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using POS.Repository;

namespace POS.Service
{
    public class CategoryService
    {
        private readonly ApplicationDBContext _context;
        public CategoryService(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<CategoriesEntity> GetCategories()
        {
            return _context.categoryEntities.ToList();
        }

        public CategoriesEntity View(int? id)
        {
            var category = _context.categoryEntities.Find(id);
            return category;
        }

        public void Add(CategoriesEntity category)
        {
            _context.categoryEntities.Add(category);
            _context.SaveChanges();
        }

        public void Update(CategoriesEntity category)
        {
            _context.categoryEntities.Update(category);
            _context.SaveChanges();
        } 

        public void Delete(int? id) 
        {
            var category = View(id);
            _context.categoryEntities.Remove(category);
            _context.SaveChanges();
        }
    }
}
