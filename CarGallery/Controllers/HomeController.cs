using Car.DataLayer.Services.Interfaces;
using CarGallery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarGallery.Controllers
{
    public class HomeController : Controller
    {
       private ICarService _carService;
       public HomeController(ICarService carService)
        {
            _carService = carService;
        }
        public IActionResult Index()
        {
            return View(_carService.GetCar());
        }
        public IActionResult Detail(int id)
        {
            var car = _carService.GetCarDetail(id);
            if(car==null)
            {
                return NotFound();
            }
            return View(car);
        }
   
        public IActionResult Archive(List<int> SelectGroups = null)
        {
            return View(_carService.GetCar(SelectGroups));
        }
        public IActionResult Agency(int id)
        {
            var agency = _carService.GetByAgencyId(id);
            return View(agency);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
