using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domain.Entities;
using TravelAgency.Domain.Abstract;
using System.Web.Mvc;

namespace TravelAgency.Domain.Concrete
{
    public class EFHotelRepository : IHotelRepository
    {
        Context context;
        public EFHotelRepository()
        {
            context = new Context();
        }
        public IEnumerable<Hotel> Hotels
        {
            get
            {
                return context.Hotel;
            }
        }
        public IEnumerable<SelectListItem> SelectCity
        {
            get
            {
                var query = from cities in context.City select cities;
                var tmp = query.AsEnumerable();
                foreach (var item in tmp)
                    yield return new SelectListItem
                    {
                        Value = item.Id.ToString(),
                        Text = item.Name
                    };
            }
        }
        public IEnumerable<SelectListItem> SelectAllocationType 
        { 
            get
            {
                var query = from types in context.AllocationType select types;
                var tmp = query.AsEnumerable();
                foreach (var item in tmp)
                    yield return new SelectListItem
                    {
                        Value = item.Id.ToString(),
                        Text = item.AllocationType1
                    };
            }
        }
        public void UpdateCreate(Hotel hotel)
        {
            if (hotel.Id == 0)
            {
                var selectmaxnum = from tours in context.Hotel select context.Hotel.Max(x => x.Id);
                int maxnum = Convert.ToInt32(selectmaxnum.First()) + 1;
                hotel.Id = maxnum;
                context.Hotel.Add(hotel);
            }
            else
            {
                Hotel dbEntry = context.Hotel.Find(hotel.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = hotel.Name;
                    dbEntry.Stars = hotel.Stars;
                    dbEntry.NightPrice = hotel.NightPrice;
                    dbEntry.CityId = hotel.CityId;

                }
            }
            context.SaveChanges();
        }
        public Hotel Delete(int id)
        {
            Hotel dbEntry = context.Hotel.Find(id);
            if (dbEntry != null)
            {
                context.Hotel.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
