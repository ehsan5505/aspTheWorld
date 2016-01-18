using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using System;
using System.Threading.Tasks;
using TheWorld.Models;
using TheWorld.ModelView;

namespace TheWorld.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<WorldUser> _signInManager;

        public AccountController(SignInManager<WorldUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Tours","App");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm,string returnUrl)
        {
            //check the model is valid
            if (ModelState.IsValid)
            {
                //now now signing the user
                var signResult=await _signInManager.PasswordSignInAsync(vm.Username, vm.Password, true, false);

                if (signResult.Succeeded)
                {
                    //redirect to the path if return value is not found
                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return RedirectToAction("Tours", "App");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    //if signin not succedd then there may be the chance of invalid
                    //username AND password
                    ModelState.AddModelError("", "Invalid Username and Password");
                }

            }
            //if not valid then return to the login
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }
            return RedirectToAction("Index", "App");
        }
    }
}
