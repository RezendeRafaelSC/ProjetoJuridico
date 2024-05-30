using Juri.Controllers;
using JuridicoProjeto.Data;
using JuridicoProjeto.Models;
using JuridicoProjeto.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JuridicoProjeto.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly  UserManager<Usuario> _userManager;
        private readonly DataContext _dataContext;


        public AccountController(SignInManager<Usuario> signInManager, UserManager<Usuario> userManager, DataContext dataContext)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid) 
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded) 
                {
                    if (returnUrl == null || returnUrl == "/")
                    {
                        return RedirectToAction("Index", "Home"); 
                    }
                }
                ModelState.AddModelError("", "Credenciais não autenticadas!");
                
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
                var usuario = new Usuario { UserName = model.Email, Email = model.Email, Name = model.Name, Cpf = model.Cpf };
                var resultLocal = await _userManager.CreateAsync(usuario, model.Password);
                if (model.isAdvogado)
                {
                    var resultOab = await _userManager.FindByEmailAsync(model.Email);
                    var advogado = new Advogado {Id = Guid.NewGuid().ToString(), UserId = resultOab.Id, oab = model.Oab };
                    _dataContext.Advogado.Add(advogado); 
                    _dataContext.SaveChanges();
                }
                if (resultLocal.Succeeded) 
                {

                    await _signInManager.SignInAsync(usuario, false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in resultLocal.Errors) {
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

        private IActionResult RedirectToLocal(string? returnUrl)
        {
            return !string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl)
                ? Redirect(returnUrl)
                : RedirectToAction(nameof(HomeController.Index), nameof(HomeController));
        }

    }
}
