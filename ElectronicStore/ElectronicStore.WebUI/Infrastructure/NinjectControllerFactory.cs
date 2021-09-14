using ElectronicStore.Core;
using ElectronicStore.Core.Repositories;
using ElectronicStore.WebUI.Infrastructure.Abstract;
using ElectronicStore.WebUI.Infrastructure.Concrete;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ElectronicStore.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
            ? null
            : (IController)ninjectKernel.Get(controllerType);
        }

        public void AddBindings()
        {
            ninjectKernel.Bind<IProductRepo>().To<ProductRepo>();
            ninjectKernel.Bind<IClientRepo>().To<ClientRepo>();
            ninjectKernel.Bind<ISellerRepo>().To<SellerRepo>();
            ninjectKernel.Bind<ISaleRepo>().To<SaleRepo>();
            ninjectKernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}