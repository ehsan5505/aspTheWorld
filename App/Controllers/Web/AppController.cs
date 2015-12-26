using System;
using Microsoft.AspNet.Mvc;
using App.ViewModel;
using App.Services;

namespace App.Controllers.Web{

    public class AppController : Controller {
        //private IMailService _mailService;

        //public AppController(IMailService service)
        //{
        //    _mailService = service;
        //}

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
        [HttpPost]
        public IActionResult Contact(ContactModel model)
        {
            //ViewBag.Message = data;
            //_mailService.SendMail("", "", $"Contact Page from {data.Name} ({data.Email})",data.Message);
            ViewBag.msg = $"{model.Name} <{model.Email}> has sent a message!";
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