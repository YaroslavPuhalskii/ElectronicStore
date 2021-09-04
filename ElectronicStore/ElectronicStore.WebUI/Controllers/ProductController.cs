using AutoMapper;
using ElectronicStore.Core;
using ElectronicStore.Entities.Models;
using ElectronicStore.WebUI.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ElectronicStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo repo;
        public ProductController(IProductRepo productRepo)
        {
            repo = productRepo;
        }

        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<PartialViewResult> Load(int? page)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductIndexView>());
            var map = new Mapper(config);
            var products = map.Map<List<ProductIndexView>>(await repo.GetItems());

            int pageSize = 3;
            int pageNumber = page ?? 1;

            return PartialView(products.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public async Task<PartialViewResult> Details(int id)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductIndexView>());
                var map = new Mapper(config);
                var product = map.Map<Product, ProductIndexView>(await repo.GetById(id));

                return PartialView(product);
            }
            catch
            {
                return PartialView("~/Views/Shared/Error.cshtml");
            }
        }
    }
}