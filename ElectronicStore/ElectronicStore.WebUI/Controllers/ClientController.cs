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
    public class ClientController : Controller
    {
        private readonly IClientRepo repo;

        public ClientController(IClientRepo clientRepo)
        {
            repo = clientRepo;
        }
        // GET: Client
        public ViewResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> Load(int? page)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Client, ClientIndexView>());
            var map = new Mapper(config);
            var clients = map.Map<IEnumerable<ClientIndexView>>(await repo.GetItems());

            int pageSize = 3;
            int pageNumber = page ?? 1;

            return PartialView(clients.ToPagedList(pageNumber, pageSize));
        }

        public async Task<PartialViewResult> Details(int id)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Client, ClientIndexView>());
                var map = new Mapper(config);
                var product = map.Map<Client, ClientIndexView>(await repo.GetById(id));

                return PartialView(product);
            }
            catch
            {
                return PartialView("~/Views/Shared/Error.cshtml");
            }
        }
    }
}