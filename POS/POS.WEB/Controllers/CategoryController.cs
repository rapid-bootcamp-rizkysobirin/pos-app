using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class CategoryController : Controller
    {

        private readonly CategoryService _service;
        public CategoryController(ApplicationDBContext context)
        {
            _service = new CategoryService(context);

        }
        public IActionResult Index()
        {
            var data = _service.GetCategories();
            return View(data);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var category = _service.View(id);
            return View(category);
        }

        [HttpGet]
        public IActionResult DetailsModal(int? id)
        {
            var category = _service.View(id);
            return PartialView(category);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddModal()
        {
            return PartialView("_Add");
        }
        [HttpPost]
        public IActionResult Save([Bind("CategoryName, Description")] CategoryModel request)
        {

            if (ModelState.IsValid)
            {
                _service.Add(new CategoriesEntity(request));
                return Redirect("Index");
            }
            return View("Add", request);
            
        }
        //ini tanpa validasi
        /*public IActionResult Save([Bind("CategoryName, Description")] CategoriesEntity request)
        {
            _service.Add(request);
            return Redirect("Index");
        }*/


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            _service.Delete(id);
            return Redirect("/Category");
        }

        [HttpGet]
        public IActionResult Edit(int? id) 
        {
            var category = _service.View(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Update([Bind("Id, CategoryName, Description")] CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                _service.Update(category);
                return Redirect("index");
            }
            return View("Edit", category);
        }
        
        //ini tanpa validasi
/*        public IActionResult Update([Bind("Id, CategoryName, Description")] CategoriesEntity category)
        {
            _service.Update(category);
            return Redirect("Index");
        }*/
    }
}
