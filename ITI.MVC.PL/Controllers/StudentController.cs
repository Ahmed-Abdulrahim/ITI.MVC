using ITI.MVC.BLL.Interface;
using ITI.MVC.BLL.Repo;
using ITI.MVC.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITI.MVC.PL.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IEntityType<Student> studentRepo;
        private readonly IEntityType<Department> deptRepo;

        public StudentController(IEntityType<Student> _studentRepo , IEntityType<Department> _deptRepo)
        {
            studentRepo = _studentRepo;
            deptRepo = _deptRepo;
        }
        //DisplayAll Data
        public IActionResult Index()
        {
            var model = studentRepo.GetAll();
            return View(model);
        }


        //Details
        [HttpGet]
        public IActionResult Details(int? id) 
        {
            if (id == null) return BadRequest();
            var model = studentRepo.Get(id.Value);
            if (model == null) return BadRequest();
            return View(model);
            
        }
        //AddData
        [HttpGet]
        public IActionResult Create() 
        {
            var DepartmentList = deptRepo.GetAll();
            ViewData["Depts"] = DepartmentList;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student model)
        {
            if (((StudentRepo)studentRepo).EmailExist(model.Email))
            {
                model.IsEmailExist = true;
                ModelState.AddModelError("Email", "Email already exists!");
            }

            if (ModelState.IsValid)
            {
                studentRepo.Add(model);
                var rowAffected = studentRepo.Save();
                if (rowAffected > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            ViewData["Depts"] = deptRepo.GetAll(); 
            return View(model);
        }

        //AddData
        [HttpGet]
        public IActionResult Edit(int? id) 
        {
            if (id == null) return BadRequest();
            var model = studentRepo.Get(id.Value);
            if (model == null) return NotFound();
            ViewData["Depts"] = deptRepo.GetAll();
            return View(model);
        }

        //SaveData
        [HttpPost]
        public IActionResult Edit(int? id , Student model)
        {
            if (((StudentRepo)studentRepo).EmailExist(model.Email))
            {
                model.IsEmailExist = true;
                ModelState.AddModelError("Email", "Email already exists!");
            }

            if (ModelState.IsValid) 
            {
                if (id == model.Id) 
                {
                    studentRepo.Update(model);
                    var rowAffected = studentRepo.Save();
                    if (rowAffected > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ViewData["Depts"] = deptRepo.GetAll();
            return View(model);
        }
        //Delete
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var model = studentRepo.Get(id.Value);
            studentRepo.Delete(model);
            var rowAffected = studentRepo.Save();
            if (rowAffected > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
