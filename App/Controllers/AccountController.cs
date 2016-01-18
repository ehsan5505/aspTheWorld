using Microsoft.AspNet.Mvc;
using System;

namespace TheWorld.Controllers
{
    public class AccountController : Controller
    {

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Tours","App");
            }

            return View();
        }

    }
}
