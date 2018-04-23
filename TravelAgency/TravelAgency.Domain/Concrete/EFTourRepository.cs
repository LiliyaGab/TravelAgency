using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domain.Abstract;
using TravelAgency.Domain.Entities;
using System.Web.Mvc;

namespace TravelAgency.Domain.Concrete
{
    public class EFTourRepository : ITourRepository
    {
        Context context;
        public EFTourRepository()
        {
            context = new Context();
        }
        public IEnumerable<Tour> Tours
        {
            get
            {
                return context.Tour;
            }
        }
        public IEnumerable<SelectListItem> SelectType
        {
           get
           {
               var query = from types in context.TourType select types;
               var tmp = query.AsEnumerable();
               foreach (var item in tmp)
                   yield return new SelectListItem
                   {
                       Value = item.Id.ToString(),
                       Text = item.Type,
                   };
           }
                
        }
        public IEnumerable<SelectListItem> SelectFoodType
        {
            get
            {
                var query = from types in context.FoodType select types;
                var tmp = query.AsEnumerable();
                foreach (var item in tmp)
                    yield return new SelectListItem
                    {
                        Value = item.Id.ToString(),
                        Text = item.FoodType1,
                    };
            }
               
            
        }
        public IEnumerable<SelectListItem> SelectHotel
        {
            get
            {
                var query = from hotels in context.Hotel select hotels;
                var tmp = query.AsEnumerable();
                foreach (var item in tmp)
                    yield return new SelectListItem
                    {
                        Value = item.Id.ToString(),
                        Text = item.Name
                    };
            }
           
        }
        public Tour DeleteTour(int id)
        {
            Tour dbEntry = context.Tour.Find(id);
            if (dbEntry != null)
            {
                context.Tour.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
       
        public void UpdateCreateTour(Tour tour)
        {
            if(tour.Id == 0)
            {
                var selectmaxnum = from tours in context.Tour select context.Tour.Max(x => x.Id);
                int maxnum = Convert.ToInt32(selectmaxnum.First()) + 1;
                tour.Id = maxnum;
                context.Tour.Add(tour);
            }
            else
            {
                Tour dbEntry = context.Tour.Find(tour.Id);
                if (dbEntry != null)
                {
                    dbEntry.StartDate = tour.StartDate;
                    dbEntry.EndDate = tour.EndDate;
                    dbEntry.FoodType = tour.FoodType;
                    dbEntry.HotelId = tour.HotelId;
                    dbEntry.Type = tour.Type;
                    dbEntry.Description = tour.Description;
                }
            }
            context.SaveChanges();
        }
        public void Select(Tour tour)
        {
            tour.SelectType = SelectType;
            tour.SelectFoodType = SelectFoodType;
            tour.SelectHotel = SelectHotel;
        }
    }
}
