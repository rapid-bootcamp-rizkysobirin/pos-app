using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService _service;
        private readonly CustomerService _serviceCustomer;
        private readonly EmployeeService _serviceEmployee;


        public OrderController(ApplicationDBContext context)
        {
            _serviceCustomer= new CustomerService(context);
            _serviceEmployee= new EmployeeService(context);
            _service = new OrderService(context);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = _service.GetOrders();
            return View(data);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var order = _service.View(id);
            return View(order);

        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddModal()
        {
            ViewBag.Customer = new SelectList(_serviceCustomer.GetCustomers(), "Id", "CompanyName");
            ViewBag.Employee = new SelectList(_serviceEmployee.GetEmployees(), "Id", "FirstName");
            return PartialView("_Add");
        }

        [HttpPost]
        public IActionResult Save(
            [Bind("CustomerId, EmployeeId, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry")] OrderModel request)
        {
            if (ModelState.IsValid)
            {
                 
                _service.Add(new OrdersEntity(request));
                return Redirect("Index");
            }
            return View("_Add", request);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            _service.Delete(id);
            return Redirect("/Order");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ViewBag.Customer = new SelectList(_serviceCustomer.GetCustomers(), "Id", "CompanyName");
            ViewBag.Employee = new SelectList(_serviceEmployee.GetEmployees(), "Id", "FirstName");
            var order = _service.View(id);
            return View(order);
        }

        [HttpPost]
        public IActionResult Update(
            [Bind("Id, CustomerId, EmployeeId, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry")] OrderModel request)
        {
            if (ModelState.IsValid)
            {
                _service.Update(request);
                return Redirect("Index");
            }
            return View("Edit", request);
        }

        public IActionResult Detail()
        {
            OrderModel order = new OrderModel();
            return View();
        }
    }
}
