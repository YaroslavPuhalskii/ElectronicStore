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
    public class SaleController : Controller
    {
        private readonly ISaleRepo repo;

        public SaleController(ISaleRepo saleRepo)
        {
            repo = saleRepo;
        }

        public ViewResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> Load(int? page, SaleFilter filter)
        {
            var items = await repo.GetItems();

            if (filter.ClientFirstName != null)
                items = items.Where(x => x.Client.FirstName == filter.ClientFirstName);

            if (filter.ClientLastName != null)
                items = items.Where(x => x.Client.LastName == filter.ClientLastName);

            if (filter.Product != null)
                items = items.Where(x => x.Product.Name == filter.Product);

            if (filter.Seller != null)
                items = items.Where(x => x.Seller.Name == filter.Seller);

            if (filter.Price > 0)
                items = items.Where(x => x.Price == filter.Price);

            if (filter.Date > 2000 && filter.Date < DateTime.Now.Year)
                items = items.Where(x => x.SaleDate.Year == filter.Date);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Sale, SaleIndexView>()
            .ForMember("Client", opt => opt.MapFrom(c => c.Client.FirstName))
            .ForMember("Product", opt => opt.MapFrom(p => p.Product.Name))
            .ForMember("Seller", opt => opt.MapFrom(s => s.Seller.Name)));
            var map = new Mapper(config);
            var sales = map.Map<IEnumerable<Sale>, IEnumerable<SaleIndexView>>(items);

            ViewBag.Filter = new SaleFilter();

            int pageSize = 3;
            int pageNumber = page ?? 1;

            return PartialView(sales.ToPagedList(pageNumber, pageSize));
        }
    }
}