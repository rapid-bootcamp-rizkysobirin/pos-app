using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using POS.Repository;
using POS.ViewModel;

namespace POS.Service
{
    public class CategoryService
    {
        private readonly ApplicationDBContext _context;
        /*==tambahan*/
        /*        private CategoryModel EntityToModel(CategoriesEntity entity)
                {
                    CategoryModel result = new CategoryModel();
                    result.Id= entity.Id;
                    result.CategoryName = entity.CategoryName;
                    result.Description= entity.Description;

                    return result;
                }*/
        /*==========*/

        private CategoryModel EntityToModel(CategoriesEntity entity)
        {
            CategoryModel result = new CategoryModel();
            result.Id = entity.Id;
            result.CategoryName = entity.CategoryName;
            result.Description = entity.Description;

            return result;
        }

        private void ModelToEntity(CategoryModel model, CategoriesEntity entity)
        {
            entity.CategoryName = model.CategoryName;
            entity.Description = model.Description;
        }


        public CategoryService(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<CategoriesEntity> GetCategories()
        {
            return _context.categoryEntities.ToList();
        }

        /*public CategoriesEntity View(int? id)*/ //ini biasa
        public CategoryModel View(int? id)
        {
            var category = _context.categoryEntities.Find(id);
            /*return category; */
            //kalo pake model
            return EntityToModel(category);
        }

        public void Add(CategoriesEntity category)
        {
            _context.categoryEntities.Add(category);
            _context.SaveChanges();
        }


        //cara biasa update
        /*public void Update(CategoriesEntity category)
        {
            _context.categoryEntities.Update(category);
            _context.SaveChanges();
        } 
        */

        //update ada validasi
        public void Update(CategoryModel category)
        {
            var entity = _context.categoryEntities.Find(category.Id);
            ModelToEntity(category, entity);
            _context.categoryEntities.Update(entity);
            _context.SaveChanges();
        }

        /*public void Delete(int? id) 
        {
            var category = View(id);
            _context.categoryEntities.Remove(category);
            _context.SaveChanges();
        }*/
        public void Delete(int? id)
        {
            var category = _context.categoryEntities.Find(id);

            _context.categoryEntities.Remove(category);
            _context.SaveChanges();
        }
    }
}
