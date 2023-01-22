using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerService _service;
        public CustomerController(ApplicationDBContext context)
        {
            _service = new CustomerService(context);

        }
        public IActionResult Index()
        {
            var data = _service.GetCustomers();
            return View(data);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var customer = _service.View(id);
            return View(customer);
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
        public IActionResult Save([Bind("CustomerName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax")] CustomerModel request) //CustomersEntity klo class entity tanpa validasi
        {
            //tanpa validasi
            /*_service.Add(request);
            return Redirect("Index");*/

            //dg validasi
            if (ModelState.IsValid)
            {
                _service.Add(new CustomersEntity(request));
                return Redirect("Index");
            }
            return View("Add", request);

        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            _service.Delete(id);
            return Redirect("/Customer");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var customer = _service.View(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Update([Bind("Id, CustommerName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax")] CustomerModel customer)// model untuk validasi, entity tnpa validasi
        {
            //tanpa validasi
            /*_service.Update(customer);
            return Redirect("Index");*/

            //dg validasi
            if (ModelState.IsValid)
            {
                _service.Update(customer);
                return Redirect("Index");
            }
            return View("Edit", customer);
        }
    }
}
