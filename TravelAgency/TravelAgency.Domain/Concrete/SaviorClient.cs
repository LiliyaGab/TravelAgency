using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Domain.Abstract;
using TravelAgency.Domain.Entities;
using System.Security.Cryptography;


namespace TravelAgency.Domain.Concrete
{
    public class SaviorClient : ISavior
    {
        Context context;
        static SHA1 hashFunc;
        public SaviorClient()
        {
            context = new Context();
            hashFunc = SHA1Managed.Create();
        }
        private byte[] ComputeHash(string text, int salt)
        {
            Byte[] bytearr = Encoding.Default.GetBytes(text + salt.ToString());
            Byte[] hasharr = hashFunc.ComputeHash(bytearr);
            return hasharr;
        }
        public void AddClientToDb(Client client)
        {
            var selectmaxnum = from client2 in context.Client select context.Client.Max(x => x.Id);
            int maxnum = Convert.ToInt32(selectmaxnum.First())+1;
            client.Id = maxnum;
            client.User.Password = Encoding.Default.GetString(ComputeHash(client.User.Password, maxnum));
            context.Client.Add(client);
        }
        public bool IsLoginUnique(Client client)
        {
            var inquiry = from users in context.User
                          where users.Login == client.User.Login
                          select users.Id;
            if (!inquiry.Any())
                return true;
            else return false;
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
