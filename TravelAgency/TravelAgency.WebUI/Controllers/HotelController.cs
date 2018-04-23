using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.Domain.Abstract;
using TravelAgency.Domain.Entities;

namespace TravelAgency.WebUI.Controllers
{
    public class HotelController : Controller
    {
        //
        // GET: /Hotel/
        IHotelRepository repository;
        public HotelController(IHotelRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Hotels);
        }
        [HttpGet]
        public ViewResult Edit(int id)
        {
            Hotel hotel = repository.Hotels.FirstOrDefault(t => t.Id == id);
            hotel.SelectCity = repository.SelectCity;
            hotel.SelectAllocationType = repository.SelectAllocationType;
            return View(hotel);
        }
        [HttpPost]
        public ActionResult Edit(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateCreate(hotel);
                TempData["message"] = string.Format("Изменения в отеле \"{0}\" были сохранены", hotel.Name);
                return RedirectToAction("Index");
            }
            hotel.SelectCity = repository.SelectCity;
            hotel.SelectAllocationType = repository.SelectAllocationType;
            return View(hotel);
        }
        public ViewResult Create(Hotel hotel)
        {
            Hotel tour = new Hotel();
            hotel.SelectCity = repository.SelectCity;
            hotel.SelectAllocationType = repository.SelectAllocationType;
            return View("Edit", hotel);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Hotel deletedHotel = repository.Delete(id);
            if (deletedHotel != null)
            {
                TempData["message"] = string.Format("Отель \"{0}\" был удален", deletedHotel.Name);
            }
            return RedirectToAction("Index");
        }
    }
}
