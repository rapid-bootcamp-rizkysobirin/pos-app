using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;

namespace POS.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _service;
        public ProductController(ApplicationDBContext context)
        {
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
            return View(product);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Save([Bind("ProductName, Supplier, Category, Quantity, UnitPrice, UnitInStock, UnitInOrder, ReorderLevel, Discontinued")] ProductsEntity request)
        {
            _service.Add(request);
            return Redirect("Index");
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
            var product = _service.View(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Update([Bind("Id, ProductName, Supplier, Category, Quantity, UnitPrice, UnitInStock, UnitInOrder, ReorderLevel, Discontinued")] ProductsEntity product)
        {
            _service.Update(product);
            return Redirect("Index");
        }

    }
}
