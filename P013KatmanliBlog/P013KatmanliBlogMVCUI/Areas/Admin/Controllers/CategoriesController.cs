using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using P013KatmanliBlog.Core.Entities;
using P013KatmanliBlog.Service.Abstract;
using P013KatmanliBlogMVCUI.Utils;

namespace P013KatmanliBlogMVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IService<Category> _service;

        public CategoriesController(IService<Category> service)
        {
            _service = service;
        }

        // GET: CategoriesController
        public async Task<ActionResult> Index()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoriesController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.ParentId= new SelectList(await _service.GetAllAsync(),"Id","Name");
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Category collection, IFormFile? Image)
        {
            try
            {
                if (Image is not null)
                {
                    collection.Image = await FileLoader.FileLoaderAsync(Image);
                }
                await _service.AddAsync(collection);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ParentId = new SelectList(await _service.GetAllAsync(), "Id", "Name");
                return View();
            }
        }

        // GET: CategoriesController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var model = await _service.FindAsync(id.Value);
            if (model == null)
            {
                return NotFound();
            }
            ViewBag.ParentId = new SelectList(await _service.GetAllAsync(), "Id", "Name");
            return View();
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Category collection, IFormFile? Image, bool resmiSil)
        {
            try
            {
                if (Image is not null) 
                {
                    collection.Image = await FileLoader.FileLoaderAsync(Image);                
                }

                if (resmiSil !=null && resmiSil==true)
                {
                    FileLoader.FileRemover(collection.Image);
                    collection.Image = "";
                }
                _service.Update(collection);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ParentId = new SelectList(await _service.GetAllAsync(), "Id", "Name");
                return View();
            }
        }

        // GET: CategoriesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: CategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category collection)
        {
            try
            {
                FileLoader.FileRemover(collection.Image);
                _service.Delete(collection);
                _service.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
