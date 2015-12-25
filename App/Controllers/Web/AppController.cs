using System;
using Microsoft.AspNet.Mvc;

namespace App.Controllers.Web{
    
    public class AppController : Controller {
        
        public IActionResult Index(){
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }
        
    }
    
}