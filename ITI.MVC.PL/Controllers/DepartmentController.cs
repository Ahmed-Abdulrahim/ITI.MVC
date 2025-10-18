using ITI.MVC.BLL.Interface;
using ITI.MVC.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ITI.MVC.PL.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IEntityType<Department> departmentRepo;

        public DepartmentController(IEntityType<Department> _departmentRepo)
        {
            departmentRepo = _departmentRepo;
        }
        //ShowAllData
        public IActionResult Index()
        {
            var DepartmentList = departmentRepo.GetAll();
            return View(DepartmentList);
        }

        //Add Data
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        //Details
        [HttpGet]
        public IActionResult Details(int? id) 
        {
            if (id == null) return BadRequest();
            var model = departmentRepo.Get(id.Value);
            if (model == null) return BadRequest();
            return View(model);
        }
        //AddToDataBase
        [HttpPost]
        public IActionResult Create(Department model)
        {
            if (ModelState.IsValid) 
            {
                departmentRepo.Add(model);
                var rowAffected = departmentRepo.Save();
                if (rowAffected > 0) 
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        //Edit
        [HttpGet]
        public IActionResult Edit(int? id) 
        {
            if(id==null) return NotFound();
            var model = departmentRepo.Get(id.Value);
            if (model == null) return NotFound();
            return View(model);
        }
        //Update Data
        [HttpPost]
        public IActionResult Edit(int? id , Department model)
        {
            if (ModelState.IsValid) 
            {
                if (id != model.Id) return BadRequest();
               departmentRepo.Update(model);
                int rowAffected = departmentRepo.Save();
                if (rowAffected > 0) 
                {
                  return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        //Delete
        [HttpPost]
        public IActionResult Delete(int? id) 
        {
            if (id == null) return NotFound();
            var model =departmentRepo.Get(id.Value);
            departmentRepo.Delete(model);
            var rowAffected = departmentRepo.Save();
            if (rowAffected > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
