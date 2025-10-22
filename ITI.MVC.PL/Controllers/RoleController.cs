using ITI.MVC.BLL.Repo;
using ITI.MVC.DAL.Models;
using ITI.MVC.PL.Dto;
using ITI.MVC.PL.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ITI.MVC.PL.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> userRole;
        private readonly UserManager<AppUser> userManager;

        public RoleController(RoleManager<IdentityRole> userRole , UserManager<AppUser> userManager)
        {
            this.userRole = userRole;
            this.userManager = userManager;
        }
        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var roles = userRole.Roles.ToList(); 

            var roleDtos = new List<RoleDto>();

            foreach (var r in roles)
            {
                roleDtos.Add(new RoleDto
                {
                    Id = r.Id,
                    Name = r.Name
                });
            }

            return View(roleDtos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleDto model)
        {
            if (ModelState.IsValid)
            {
                var role = await  userRole.FindByNameAsync(model.Name);
                if (role is null)
                {
                    role = new IdentityRole
                    {
                        Name = model.Name,
                    };
                    var res = await userRole.CreateAsync(role);
                    if (res.Succeeded) 
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null) return BadRequest();
            var user = await userRole.FindByIdAsync(id);
            if (user == null) return NotFound();
            var dto = new RoleDto()
            {
                Id = user.Id,
                Name = user.Name,
            };
            return View(dto);
        }
        //Edit
        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null) return NotFound();
            var role = await userRole.FindByIdAsync(id);
            if (role == null) return NotFound();
            var dto = new RoleDto()
            {
                Id = role.Id,
                Name = role.Name,
            };
            return View(dto);
        }
        //Update Data
        [HttpPost]
        public async Task<IActionResult> Edit(string? id, RoleDto model)
        {
            if (ModelState.IsValid)
            {
                if (id != model.Id) return BadRequest();
                var user = await userRole.FindByIdAsync(id);
                if (user == null) return NotFound();
                user.Name = model.Name;
               
                var res = await userRole.UpdateAsync(user);
                if (res.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string? id)
        {
            if (ModelState.IsValid)
            {
                if (id == null) return BadRequest();
                var user = await userRole.FindByIdAsync(id);
                if (user == null) return NotFound();
                var res = await userRole.DeleteAsync(user);
                if (res.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return Content("Not Valid ", contentType: "text/html");
        }
        [HttpGet]
        public async Task<IActionResult> AddOrRemoveUser(string? id) 
        {
            if(id==null) return BadRequest();
            var role = await userRole.FindByIdAsync(id);
            ViewData["Role"] = id;
            if(role==null) return NotFound();
            var UserInRole = new List<UserInRoleViewModel>();
            var users = await userManager.Users.ToListAsync();
            foreach (var user in users) 
            {
                var u = new UserInRoleViewModel
                {
                    Id = user.Id,
                    Name = user.UserName,
                };
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    u.IsSelected = true;
                }
                else 
                {
                    u.IsSelected = false;
                }
                UserInRole.Add(u);
            }

            return View(UserInRole);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrRemoveUser(string? id, List<UserInRoleViewModel> users) 
        {
            var role = await userRole.FindByIdAsync(id);
            if(id == null )return BadRequest();
            if (ModelState.IsValid) 
            {
                foreach(var user in users) 
                {
                    var appUser = await userManager.FindByIdAsync(user.Id);
                    if (appUser is not null) 
                    {
                        if (user.IsSelected && !await userManager.IsInRoleAsync(appUser, role.Name))
                        {
                            await userManager.AddToRoleAsync(appUser, role.Name);
                        }
                        else if (!user.IsSelected && await userManager.IsInRoleAsync(appUser, role.Name)) 
                        {
                            await userManager.AddToRoleAsync(appUser, role.Name);
                        }
                    }
                }
                return RedirectToAction("Index", "User");
            }
            return View(users);
        }
    }
}

