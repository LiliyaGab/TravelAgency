using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domain.Entities;
using System.Web.Mvc;

namespace TravelAgency.Domain.Abstract
{
    public interface IHotelRepository
    {
        IEnumerable<Hotel> Hotels { get; }
        IEnumerable<SelectListItem> SelectCity { get; }
        IEnumerable<SelectListItem> SelectAllocationType { get; }

        void UpdateCreate(Hotel hotel);
        Hotel Delete(int id);
    }
}
