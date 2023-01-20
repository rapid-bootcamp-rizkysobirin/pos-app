using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _service;
        private readonly CategoryService _serviceCategory;
        private readonly SupplierService _serviceSupplier;
        public ProductController(ApplicationDBContext context)
        {
            _serviceSupplier = new SupplierService(context); 
            _serviceCategory= new CategoryService(context);
            _service = new ProductService(context);
        }

        public IActionResult Index()
        {
            var data = _service.GetProducts();
            return View(data);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var product = _service.View(id);
            /*var product = _service.ViewProductResponse(id);*/
            return View(product);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddModal()
        {
            ViewBag.Categories = new SelectList(_serviceCategory.GetCategories(), "Id", "CategoryName");
            ViewBag.Suppliers = new SelectList(_serviceSupplier.GetSuppliers(), "Id", "CompanyName");
            return PartialView("_Add");
        }

        [HttpPost]
        public IActionResult Save(
            [Bind("ProductName, SupplierId, CategoryId, Quantity, UnitPrice, UnitInStock, UnitInOrder, ReorderLevel, Discontinued")] ProductModel request)
        {
            if (ModelState.IsValid)
            {
                _service.Add(new ProductsEntity(request));
                return Redirect("Index");
            }
            return View("Add", request);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            _service.Delete(id);
            return Redirect("/Product");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ViewBag.Categories = new SelectList(_serviceCategory.GetCategories(), "Id", "CategoryName");
            ViewBag.Suppliers = new SelectList(_serviceSupplier.GetSuppliers(), "Id", "CompanyName");
            var product = _service.View(id);
           /* var product = _service.View(id);*/
            return View(product);
        }
        [HttpPost]
        public IActionResult Update(
            [Bind("Id, ProductName, SupplierId, CategoryId, Quantity, UnitPrice, UnitInStock, UnitInOrder, ReorderLevel, Discontinued")] ProductModel request)
        {
            if (ModelState.IsValid)
            {
                _service.Update(request);
                return Redirect("Index");
            }
            return View("Edit", request);
        }
    }
}
