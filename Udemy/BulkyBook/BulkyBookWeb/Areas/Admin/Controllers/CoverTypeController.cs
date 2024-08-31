using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Model;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    //[Area("Admin")]
    public class CoverTypeController : Controller
    {
       
        private readonly IUnitOfWork _UnitOfWork;

        public CoverTypeController(IUnitOfWork UnitOfWork)
        {

            _UnitOfWork = UnitOfWork;
        }
        public IActionResult Index()
        {

            IEnumerable<CoverType> objCovertypeList = _UnitOfWork.CoverType.GetAll();
            return View(objCovertypeList);
        }

        public IActionResult Create()
        {
           return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //avoid Cross site Request Forgery
        public IActionResult Create(CoverType obj)
        {
          
            if(ModelState.IsValid) //check all validation of model are valid for incoming data
            {
                _UnitOfWork.CoverType.Add(obj);
                _UnitOfWork.Save();

                TempData["Success"] = "CoverType added successfully";
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

            var coverTypeFromDb = _UnitOfWork.CoverType.GetFirstOrDefault(u=>u.Id==id);
            // var coverTypeFromDbFrist = _db.CoverType.FirstOrDefault(u => u.Id == id);
            // var coverTypeFromDbSingle = _db.CoverType.SingleOrDefault(u => u.Id == id);

            if (coverTypeFromDb == null)
            {
                return NotFound();
            }
            return View(coverTypeFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //avoid Cross site Request Forgery
        public IActionResult Edit(CoverType obj)
        {
            
            if (ModelState.IsValid) //check all validation of model are valid for incoming data
            {
                _UnitOfWork.CoverType.Update(obj);
                _UnitOfWork.Save();
                TempData["Success"] = "CoverType Updated successfully";
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

            // var coverTypeFromDb = _db.CoverType.CoverTypes.Find(id);
            var coverTypeFromDb = _UnitOfWork.CoverType.GetFirstOrDefault(u=>u.Id==id);

            if (coverTypeFromDb == null)
            {
                return NotFound();
            }
            return View(coverTypeFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //avoid Cross site Request Forgery
        public IActionResult DeletePost(int? id)
        {
            var coverTypeFromDb = _UnitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            _UnitOfWork.CoverType.Remove(coverTypeFromDb);
            _UnitOfWork.Save();
                TempData["Success"] = "CoverType Ddeleted successfully";
                return RedirectToAction("Index");
            
           
        }

    }
}
 