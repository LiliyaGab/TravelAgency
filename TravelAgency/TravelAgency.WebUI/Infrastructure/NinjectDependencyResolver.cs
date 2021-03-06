﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using Ninject;
using Moq;
using TravelAgency.Domain.Abstract;
using TravelAgency.Domain.Entities;
using TravelAgency.Domain.Concrete;


namespace TravelAgency.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        // Здесь размещаются привязки
        private void AddBindings()   
        {
            
    //        Mock<IGameRepository> mock = new Mock<IGameRepository>();
    //        mock.Setup(m => m.Games).Returns(new List<Game>
    //{
    //    new Game { Name = "SimCity", Price = 1499 },
    //    new Game { Name = "TITANFALL", Price=2299 },
    //    new Game { Name = "Battlefield 4", Price=899.4M }
    //});
    //        kernel.Bind<IGameRepository>().ToConstant(mock.Object);
            kernel.Bind<ITourRepository>().To<EFTourRepository>();
            kernel.Bind<ISavior>().To<SaviorClient>();
            kernel.Bind<IHotelRepository>().To<EFHotelRepository>();
        }
    }
}