using ITI.MVC.BLL.Repo;
using ITI.MVC.DAL.Models;
using ITI.MVC.PL.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITI.MVC.PL.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public UserController(UserManager<AppUser> _userManager)
        {
            userManager = _userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = userManager.Users.ToList(); 

            var userDtos = new List<UserRoleDto>();

            foreach (var u in users)
            {
                var roles = await userManager.GetRolesAsync(u); 

                userDtos.Add(new UserRoleDto
                {
                    Id = u.Id,
                    userName = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Roles = roles
                });
            }

            return View(userDtos);
        }
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null) return BadRequest();
            var user = await userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            var dto = new UserRoleDto()
            {
                Id = user.Id,
                userName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email, 
            };
            return View(dto);
        }
        //Edit
        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null) return NotFound();
            var user = await userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            var dto = new UserRoleDto()
            {
                Id = user.Id,
                userName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            };
            return View(dto);
        }
        //Update Data
        [HttpPost]
        public async Task<IActionResult> Edit(string? id, UserRoleDto model)
        {
            if (ModelState.IsValid)
            {
                if (id != model.Id) return BadRequest();
                var user = await userManager.FindByIdAsync(id);
                if (user == null) return NotFound();
                user.UserName = model.userName;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                var res =  await userManager.UpdateAsync(user);
                if (res.Succeeded) 
                {
                  return  RedirectToAction("Index");
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(string? id)
        {
            if (ModelState.IsValid)
            {
                if (id ==null) return BadRequest();
                var user = await userManager.FindByIdAsync(id);
                if (user == null) return NotFound();
                var res = await userManager.DeleteAsync(user);
                if (res.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return Content("Not Valid " , contentType:"text/html");
        }
    }
}
