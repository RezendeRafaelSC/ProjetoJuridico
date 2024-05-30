using JuridicoProjeto.Models;
using JuridicoProjeto.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JuridicoProjeto.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly  UserManager<Usuario> _userManager;
        

        public AccountController(SignInManager<Usuario> signInManager, UserManager<Usuario> userManager)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(Login model)
        {
            if (ModelState.IsValid) 
            {
                //login
                var result = await _signInManager.PasswordSignInAsync(model.Email!, model.Password!, model.RememberMe, false);
                if (result.Succeeded) 
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Login inválido!");
                

                return View(model);
            }


            return View(model);
        }



        public  IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {

                var user = new Usuario { UserName=model.Email, Email=model.Email, Name = model.Name, Cpf=model.Cpf  }; 
                var result = await _userManager.CreateAsync(user, model.Password!);

                if (result.Succeeded) 
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors) {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public  async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }



    }
}
