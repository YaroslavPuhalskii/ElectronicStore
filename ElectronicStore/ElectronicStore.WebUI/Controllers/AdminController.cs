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
        private ISellerRepo _sellerRepo = new SellerRepo();
        
        public AdminController()
        {

        }
        // GET: Admin
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
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

                return Json(new { result = true});
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message});
            }
        }

        // GET: Admin/Edit/5
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
        public async Task<JsonResult> EditProductUpdate(ProductEditView item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductEditView, Product>());
                    var map = new Mapper(config);
                    var product = map.Map<ProductEditView, Product>(item);

                    await productRepo.Update(product);

                    return Json(new { result = true});
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

                return Json(new { result = true});
            }

            return Json(new { result = false, message = "Model invalid" });
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
