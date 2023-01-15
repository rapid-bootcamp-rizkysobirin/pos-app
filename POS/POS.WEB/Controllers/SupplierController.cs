using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;

namespace POS.Web.Controllers
{
    public class SupplierController : Controller
    {
        private readonly SupplierService _service;
        public SupplierController(ApplicationDBContext context)
        {
            _service = new SupplierService(context);
        }

        public IActionResult Index()
        {
            var data = _service.GetSuppliers();
            return View(data);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var supplier = _service.View(id);
            return View(supplier);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Save([Bind("CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, County, Phone, Fax, Homepage")] SuppliersEntity request)
        {
            _service.Add(request);
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            _service.Delete(id);
            return Redirect("/Supplier");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var supplier = _service.View(id);
            return View(supplier);
        }
        [HttpPost]
        public IActionResult Update([Bind("Id, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, County, Phone, Fax, Homepage")] SuppliersEntity supplier)
        {
            _service.Update(supplier);
            return Redirect("Index");
        }
    }
}