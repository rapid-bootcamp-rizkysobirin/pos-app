using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class SupplierController : Controller
    {
        private readonly SupplierService _service;
        public SupplierController(ApplicationDBContext context)
        {
            _service = new SupplierService(context);
        }

        [HttpGet]
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

        [HttpGet]
        public IActionResult AddModal()
        {
            return PartialView("_Add");
        }

        [HttpPost]
        public IActionResult Save([Bind("CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax, HomePage")] SupplierModel request)
        {
            /*_service.Add(request);
            return Redirect("Index");*/

            if(ModelState.IsValid)
            {
                _service.Add(new SuppliersEntity(request));
                return Redirect("Index");
            }
            return View("Add", request);
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
        public IActionResult Update([Bind("Id, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax, HomePage")] SupplierModel supplier)
        {
            /*_service.Update(supplier);
            return Redirect("Index");*/

            if (ModelState.IsValid)
            {
                _service.Update(supplier);
                return Redirect("Index");
            }
            return View("Edit", supplier);
        }
    }
}