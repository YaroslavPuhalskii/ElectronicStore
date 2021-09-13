using AutoMapper;
using ElectronicStore.Core;
using ElectronicStore.Core.Repositories;
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
    public class AdminController : Controller
    {
        private IClientRepo clientRepo = new ClientRepo();
        private IProductRepo productRepo = new ProductRepo();
        private ISaleRepo _saleRepo = new SaleRepo();
        private ISellerRepo sellerRepo = new SellerRepo();

        public AdminController()
        {

        }

        public ViewResult Index()
        {
            return View();
        }

        #region Для продуктов

        public async Task<PartialViewResult> LoadProducts(int? page)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductIndexView>());
            var map = new Mapper(config);
            var products = map.Map<List<ProductIndexView>>(await productRepo.GetItems());

            int pageSize = 3;
            int pageNumber = page ?? 1;

            return PartialView(products.ToPagedList(pageNumber, pageSize));
        }

        public PartialViewResult CreateProduct()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<JsonResult> CreateProduct(ProductCreateView item)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductCreateView, Product>());
                var map = new Mapper(config);
                var product = map.Map<ProductCreateView, Product>(item);

                await productRepo.Insert(product);

                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message });
            }
        }

        public async Task<PartialViewResult> EditProduct(int id)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductEditView>());
                var map = new Mapper(config);
                var product = map.Map<Product, ProductEditView>(await productRepo.GetById(id));

                return PartialView(product);
            }
            catch
            {
                return PartialView("~/Views/Shared/Error.cshtml");
            }
        }

        [HttpPost]
        public async Task<JsonResult> EditProduct(ProductEditView item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductEditView, Product>());
                    var map = new Mapper(config);
                    var product = map.Map<ProductEditView, Product>(item);

                    await productRepo.Update(product);

                    return Json(new { result = true });
                }
                catch (Exception ex)
                {
                    return Json(new { result = false, message = ex.Message });
                }
            }

            return Json(new { result = false, message = "Model invalid" });
        }

        [HttpPost]
        public async Task<JsonResult> DeleteProduct(int id)
        {
            if (id > 0)
            {
                await productRepo.Remove(id);

                return Json(new { result = true });
            }

            return Json(new { result = false, message = "Model invalid" });
        }
        #endregion

        #region Для Клиентов
        public async Task<PartialViewResult> LoadClient(int? page)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Client, ClientIndexView>());
            var map = new Mapper(config);
            var clients = map.Map<List<ClientIndexView>>(await clientRepo.GetItems());

            int pageSize = 3;
            int pageNumber = page ?? 1;

            return PartialView(clients.ToPagedList(pageNumber, pageSize));
        }

        public async Task<PartialViewResult> EditClient(int id)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Client, ClientEditView>());
                var map = new Mapper(config);
                var client = map.Map<Client, ClientEditView>(await clientRepo.GetById(id));

                return PartialView(client);

            }
            catch
            {
                return PartialView("~/Views/Shared/Error.cshtml");
            }
        }
        [HttpPost]
        public async Task<JsonResult> EditClient(ClientEditView item)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientEditView, Client>());
                var map = new Mapper(config);
                var client = map.Map<ClientEditView, Client>(item);

                await clientRepo.Update(client);

                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message });
            };
        }

        public PartialViewResult CreateClient()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<JsonResult> CreateClient(ClientCreateView item)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ClientCreateView, Client>());
                var map = new Mapper(config);
                var client = map.Map<ClientCreateView, Client>(item);

                await clientRepo.Insert(client);

                return Json(new { result = true});
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message });
            }
        }

        public async Task<JsonResult> DeleteClient(int id)
        {
            if (id > 0)
            {
                await clientRepo.Remove(id);

                return Json(new { result = true });
            }

            return Json(new { result = false, message = "Model is invalid" });
        }
        #endregion

        #region Для Продавцов
        public async Task<PartialViewResult> LoadSeller(int? page)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Seller, SellerIndexView>());
            var map = new Mapper(config);
            var sellers = map.Map<List<SellerIndexView>>(await sellerRepo.GetItems());

            int pageSize = 3;
            int pageNumber = page ?? 1;

            return PartialView(sellers.ToPagedList(pageNumber, pageSize));
        }

        public async Task<PartialViewResult> EditSeller(int id)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Seller, SellerEditView>());
                var map = new Mapper(config);
                var seller = map.Map<Seller, SellerEditView>(await sellerRepo.GetById(id));

                return PartialView(seller);
            }
            catch
            {
                return PartialView("~/Views/Shared/Error.cshtml");
            }
        }
        [HttpPost]
        public async Task<JsonResult> EditSeller(SellerEditView item)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<SellerEditView, Seller>());
                var map = new Mapper(config);
                var seller = map.Map<SellerEditView, Seller>(item);

                await sellerRepo.Update(seller);

                return Json( new { result = true});
            }
            catch (Exception ex)
            {
                return Json( new { result = false, message = ex.Message});
            }
        }

        public PartialViewResult CreateSeller()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<JsonResult> CreateSeller(SellerCreateView item)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<SellerCreateView, Seller>());
                var map = new Mapper(config);
                var seller = map.Map<SellerCreateView, Seller>(item);

                await sellerRepo.Insert(seller);

                return Json( new { result = true});
            }
            catch (Exception ex)
            {
                return Json( new { result = false, message = ex.Message});
            }
        }

        public JsonResult DeleteSeller(int id)
        {
            if (id > 0)
            {
                sellerRepo.Remove(id);

                return Json(new { result = true});
            }

            return Json(new { result = false, message = "Model is invalid"});
        }
        #endregion
    }
}
