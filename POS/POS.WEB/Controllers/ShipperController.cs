using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class ShipperController : Controller
    {
        private readonly ShipperService _service;
        public ShipperController(ApplicationDBContext context)
        {
            _service = new ShipperService(context);
        }

        [HttpGet]
        public IActionResult index()
        {
            var data = _service.GetShipper();
            return View(data);

        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var data = _service.GetShipper(id);
            return View(data);

        }

        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("Add");
        }

        [HttpPost]
        public IActionResult Save(
            [Bind("CompanyName, Phone")]ShipperModel shipper)
        {
            if (ModelState.IsValid)
            {
                _service.Add(new ShipperEntity(shipper));
                return Redirect("Index");

            }

            return View("Add", shipper);
        }

        [HttpGet]
        public IActionResult Delete(int? id) {
            _service.Delete(id);
            return Redirect("/Shipper");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var data = _service.Edit(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Update([Bind("Id, CompanyName, Phone")] ShipperModel shipper)
        {
            if (ModelState.IsValid)
            {
                _service.Update(shipper);
                return Redirect("Index");
            }
            return View("Edit", shipper);
        }


    }
}
