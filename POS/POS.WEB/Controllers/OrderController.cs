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
        private readonly ShipperService _serviceShipper;
        private readonly ProductService _serviceProduct;


        public OrderController(ApplicationDBContext context)
        {
            _serviceShipper = new ShipperService(context);
            _serviceProduct = new ProductService(context);
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
            var order = _service.ViewDetail(id);
            return View(order);

        }

        [HttpGet]
        public IActionResult Add()
        {

            ViewBag.Customer = new SelectList(_serviceCustomer.GetCustomers(), "Id", "CustomerName");
            ViewBag.Employee = new SelectList(_serviceEmployee.GetEmployees(), "Id", "FirstName");
            ViewBag.Shipper = new SelectList(_serviceShipper.GetShipper(), "Id", "CompanyName");
            ViewBag.Product = new SelectList(_serviceProduct.GetProducts(), "Id", "ProductName");
            return View();
        }

        /*[HttpGet]
        public IActionResult AddModal()
        {
            ViewBag.Customer = new SelectList(_serviceCustomer.GetCustomers(), "Id", "CompanyName");
            ViewBag.Employee = new SelectList(_serviceEmployee.GetEmployees(), "Id", "FirstName");
            ViewBag.Shipper = new SelectList(_serviceShipper.GetShipper(), "Id", "CompanyName");
            ViewBag.Product = new SelectList(_serviceProduct.GetProducts(), "Id", "ProductName");
            return PartialView("_Add");
        }*/

        [HttpPost]
        public IActionResult Save(
            [Bind("CustomerId, EmployeeId, OrderDate, RequiredDate, ShippedDate, ShipperId, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry, OrderDetailsModel")] OrderModel request)
        {
            if (ModelState.IsValid)
            {
                 
                _service.Add(request);
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
            ViewBag.Shipper = new SelectList(_serviceShipper.GetShipper(), "Id", "CompanyName");
            ViewBag.Product = new SelectList(_serviceProduct.GetProducts(), "Id", "ProductName");
            var order = _service.View(id);
            return View(order);
        }

        [HttpPost]
        public IActionResult Update(
            [Bind("Id, CustomerId, EmployeeId, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry,OrderDetailsModel")] OrderModel request)
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
