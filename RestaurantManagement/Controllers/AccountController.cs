using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.DAL.Enteties;
using RestaurantManagement.Models;
using RestaurantManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _UserManager;
        private readonly SignInManager<User> _SignInManager;

        public AccountController(UserManager<User> UserManager, SignInManager<User> SignInManager)
        {
            _UserManager = UserManager;
            _SignInManager = SignInManager;
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Table");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Wrong login or passwprd");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Table");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
           
                if (ModelState.IsValid)
                {
                    User user = new User
                    {
                        FirstName = model.FirstName,
                        SecondName = model.SecondName,
                        PhoneNumber = model.PhoneNumber,
                        Email = model.Email,
                        UserName = model.Email
                    };
                    // add user
                    var result = await _UserManager.CreateAsync(user, model.Password);
                    
                    if (result.Succeeded)
                    {
                    await _UserManager.AddToRoleAsync(user, "User");
                    // cookies
                    await _SignInManager.SignInAsync(user, false);
                        return RedirectToAction("Index", "Table");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                return View(model);

            }
        }
    }

