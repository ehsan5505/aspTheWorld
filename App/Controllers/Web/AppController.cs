using Microsoft.AspNet.Mvc;
using App.ViewModel;
using TheWorld.Models;

namespace App.Controllers.Web
{

    public class AppController : Controller {
        private IWorldRepository _repository;
        //private WorldContext _context;

        //private IMailService _mailService;

        public AppController(IWorldRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index(){
            //var trips = _context.Trips.ToList();
            var trips = _repository.getAllTrips();
            return View(trips);
        }

        public IActionResult Home()
        {
            //var trips = _context.Trips.ToList();
            //return View(trips);
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