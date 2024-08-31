using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Model;
using BulkyBook.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBookWeb.Controllers
{
    //[Area("Admin")]
    public class ProductController : Controller
    {

        private readonly IUnitOfWork _UnitOfWork;
        private readonly IWebHostEnvironment _HostEnvironment;

        public ProductController(IUnitOfWork UnitOfWork, IWebHostEnvironment webHostEnvironment)
        {

            _UnitOfWork = UnitOfWork;
            _HostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //avoid Cross site Request Forgery
        public IActionResult Create(CoverType obj)
        {

            if (ModelState.IsValid) //check all validation of model are valid for incoming data
            {
                _UnitOfWork.CoverType.Add(obj);
                _UnitOfWork.Save();

                TempData["Success"] = "CoverType added successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //Get
        public IActionResult Upsert(int? id)
        {
            ProductVM ProductVM = new()
            {
                Product = new(),
                CategoryList = _UnitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                CoverTypeList = _UnitOfWork.CoverType.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };

            if (id == null || id == 0)
            {
                //ViewBag.CategoryList = CategoryList;
                //ViewData["CoverTypeList"] = CoverTypeList;
                //Create Product
                return View(ProductVM);
            }
            else
            {
                ProductVM.Product = _UnitOfWork.Product.GetFirstOrDefault(i => i.Id == id);
                return View(ProductVM);
            }


            return View(ProductVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //avoid Cross site Request Forgery
        public IActionResult Upsert(ProductVM obj, IFormFile? file)
        {

            if (ModelState.IsValid) //check all validation of model are valid for incoming data
            {
                string wwwRootPath = _HostEnvironment.WebRootPath;
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"Images\Products");
                    var extension = Path.GetExtension(file.FileName);
                    if(obj.Product.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath,obj.Product.ImageUrl.TrimStart('\\'));
                        if(System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStreams = new FileStream(Path.Combine(uploads, filename + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.Product.ImageUrl = @"\Images\Products\" + filename + extension;
                }
                if (obj.Product.Id == 0)
                {
                    _UnitOfWork.Product.Add(obj.Product);
                }
                else
                {
                    _UnitOfWork.Product.Update(obj.Product);
                }

                
                //_UnitOfWork.CoverType.Update(obj);
                _UnitOfWork.Save();
                TempData["Success"] = "Product Updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Deletepost(   int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // var coverTypeFromDb = _db.CoverType.CoverTypes.Find(id);
            var coverTypeFromDb = _UnitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

            if (coverTypeFromDb == null)
            {
                return NotFound();
            }
            return View(coverTypeFromDb);
        }

       

        #region API Calls
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _UnitOfWork.Product.GetAll(includeProperties: "Category,CoverType");
            return Json(new { data = productList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _UnitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
            if(obj == null)
            {
                return Json(new {success = false, message="Error while deleting"});
            }

            var oldImagePath = Path.Combine(_HostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _UnitOfWork.Product.Remove(obj);
            _UnitOfWork.Save();
            return Json(new { success = true, message = "Deleted successfully" });
            


        }
        #endregion

    }
}
