using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.Domain.Abstract;
using TravelAgency.Domain.Entities;

namespace TravelAgency.WebUI.Controllers
{
    public class TourController : Controller
    {
        //
        // GET: /Admin/
        ITourRepository repository;
        public TourController(ITourRepository repo)
        {
            repository = repo;
        }
        
        public ViewResult Index()
        {
            return View(repository.Tours);
        }
        [HttpGet]
        public ViewResult Edit(int id)
        {
            Tour tour = repository.Tours.FirstOrDefault(t => t.Id == id);
            repository.Select(tour);
            return View(tour);
        }
        [HttpPost]
        public ActionResult Edit(Tour tour)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateCreateTour(tour);
                TempData["message"] = string.Format("Изменения в туре \"{0}\" были сохранены", tour.Id);
                return RedirectToAction("Index");
            }
            repository.Select(tour);
            return View(tour);
        }
        public ViewResult Create()
        {
            Tour tour = new Tour();
            repository.Select(tour);
            return View("Edit", tour);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Tour deletedTour = repository.DeleteTour(id);
            if (deletedTour != null)
            {
                TempData["message"] = string.Format("Тур с ID \"{0}\" был удален", id);
            }
            return RedirectToAction("Index");
        }
        
    }
}
