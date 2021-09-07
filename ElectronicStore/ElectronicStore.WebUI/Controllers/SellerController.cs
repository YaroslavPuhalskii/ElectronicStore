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
    public class SellerController : Controller
    {
        private readonly ISellerRepo repo;
        public SellerController(ISellerRepo sellerRepo)
        {
            repo = sellerRepo;
        }
        public ViewResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> Load(int? page, SellerFilter filter)
        {
            var sellers = await repo.GetItems();

            if (filter.Name != null)
            {
                sellers = sellers.Where(x => x.Name == filter.Name);
            }

            if (filter.Description != null)
            {
                sellers = sellers.Where(x => x.Decription == filter.Description);
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Seller, SellerIndexView>()
            .ForMember("Name", opt => opt.MapFrom(s => s.Name))
            .ForMember("Description", opt => opt.MapFrom(s => s.Decription))
            .ForMember("Birth", opt => opt.MapFrom(s => s.Birth)));
            var map = new Mapper(config);
            var result = map.Map<List<SellerIndexView>>(sellers);

            ViewBag.Filter = new SellerFilter();

            int pageSize = 3;
            int pageNumber = page ?? 1;

            return PartialView(result.ToPagedList(pageNumber, pageSize));
        }
    }
}