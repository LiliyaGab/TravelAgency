using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domain.Concrete;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Domain.Abstract
{
    public interface ISavior
    {
        void AddClientToDb(Client client);
        void SaveChanges();
        bool IsLoginUnique(Client client);
    }
}
