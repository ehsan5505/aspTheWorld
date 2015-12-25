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
        
        public IActionResult Contact(){
            return View();
        }
        public IActionResult About(){
            return View();
        }
        public IActionResult Service(){
            return View();
        }
        
    }
    
}