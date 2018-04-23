using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.Domain.Abstract;
using TravelAgency.Domain.Entities;
using TravelAgency.Domain.Concrete;
using System.Data.Entity.Validation;

namespace TravelAgency.WebUI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private ITourRepository repository;
        private ISavior savior;
        public HomeController(ITourRepository repo, ISavior save)
        {
            repository = repo;
            savior = save;
        }
        public ViewResult List()
        {
            return View(repository.Tours);
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View(new Client());
        }
        [HttpPost]
        public ActionResult SignUp(Client client)
        {
            client.DOB = Convert.ToDateTime(client.BirthdateDay + "." + client.BirthdateMonth + "." + client.BirthdateYear);
            //client.DOB = Convert.ToDateTime(client.BirthdateDaySelectList.First(x => x.Selected == true).Value + "."+client.BirthdateMonthSelectList.First(x => x.Selected == true).Value + "." + client.BirthdateYearSelectList.First(x => x.Selected == true).Value);
            if (!savior.IsLoginUnique(client))
            {
                ModelState.AddModelError("Login", "Пользователь с таким логином уже зарегистрирован");
                //ViewBag.NotUniqueLogin = "Такой логин уже существует";
                return View(client);
            }    
            if (ModelState.IsValid)
            {
                savior.AddClientToDb(client);
                //savior.SaveChanges();
            }
            return View(client);
        }
        public ActionResult Index()
        {
            return View();
        }
       
    }
}
