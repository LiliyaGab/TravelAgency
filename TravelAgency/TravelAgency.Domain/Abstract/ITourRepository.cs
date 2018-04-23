using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domain.Concrete;
using TravelAgency.Domain.Entities;
using System.Web.Mvc;

namespace TravelAgency.Domain.Abstract
{
    public interface ITourRepository
    {
        //string GetHotelName();
        IEnumerable<Tour> Tours { get; }
        IEnumerable<SelectListItem> SelectType { get; }
        IEnumerable<SelectListItem> SelectFoodType { get; }
        IEnumerable<SelectListItem> SelectHotel { get; }
        void Select(Tour tour);
        Tour DeleteTour(int id);
        void UpdateCreateTour(Tour tour);
    }
}
