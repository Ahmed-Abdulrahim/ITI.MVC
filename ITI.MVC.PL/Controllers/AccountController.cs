using ITI.MVC.DAL.Models;
using ITI.MVC.PL.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace ITI.MVC.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> _userManager , SignInManager<AppUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto model)
        {
            if (ModelState.IsValid)
            {
                
                var user = await userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    ModelState.AddModelError("UserName", "Username already exists!");
                    return View(model);
                }

                
                user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    ModelState.AddModelError("Email", "Email already exists!");
                    return View(model);
                }

               
                user = new AppUser
                {
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    IsAgree = model.IsAgree,
                };

                var res = await userManager.CreateAsync(user, model.Password);

                if (res.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }

              
                foreach (var e in res.Errors)
                {
                    if (e.Description.Contains("Passwords"))
                        ModelState.AddModelError("Password", e.Description);
                    else
                        ModelState.AddModelError("", e.Description);
                }
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInDto model)
        {
            if (ModelState.IsValid) 
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null) 
                {
                    var flag = await userManager.CheckPasswordAsync(user,model.Password);
                    if (flag) 
                    {
                        var res = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                        if (res.Succeeded) 
                        {
                         return RedirectToAction("Index", "Home");
                        }
                       
                    }

                }
            }
            return View(model);
        }
        [HttpGet]
        public new async Task<IActionResult> SignOut() 
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(SignIn));
        }
    }

}
