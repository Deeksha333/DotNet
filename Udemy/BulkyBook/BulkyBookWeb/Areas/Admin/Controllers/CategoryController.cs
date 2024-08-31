using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Model;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    //[Area("Admin")]
    public class CategoryController : Controller
    {
       
        private readonly IUnitOfWork _db;

        public CategoryController(IUnitOfWork db)
        {
           
            _db = db;
        }
        public IActionResult Index()
        {

            IEnumerable<Category> objcategoryList = _db.Category.GetAll();
            return View(objcategoryList);
        }

        public IActionResult Create()
        {
           return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //avoid Cross site Request Forgery
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Custom", "Display Order can not be same");
            }
            if(ModelState.IsValid) //check all validation of model are valid for incoming data
            {
                _db.Category.Add(obj);
                _db.Save();

                TempData["Success"] = "Category added successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }
            //Single : signle give error when  field is empty
            //Single or default : will not give exception as the case of single . but it will give exception when there is multiple elements.
            //FristOrDefalt: will not throw any exception if there is multiple element.
            //find: tries to find out the primary key  based on table

            var categoryFromDb = _db.Category.GetFirstOrDefault(u=>u.Id==id);
            // var categoryFromDbFrist = _db.Categories.FirstOrDefault(u => u.Id == id);
            // var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if(categoryFromDb ==null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //avoid Cross site Request Forgery
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Custom", "Display Order can not be same");
            }
            if (ModelState.IsValid) //check all validation of model are valid for incoming data
            {
                _db.Category.Update(obj);
                _db.Save();
                TempData["Success"] = "Category Updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
           
           // var categoryFromDb = _db.Category.Categories.Find(id);
            var categoryFromDb = _db.Category.GetFirstOrDefault(u=>u.Id==id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //avoid Cross site Request Forgery
        public IActionResult DeletePost(int? id)
        {
            var categoryFromDb = _db.Category.GetFirstOrDefault(u => u.Id == id);
            _db.Category.Remove(categoryFromDb);
            _db.Save();
                TempData["Success"] = "Category Ddeleted successfully";
                return RedirectToAction("Index");
            
           
        }

    }
}
 