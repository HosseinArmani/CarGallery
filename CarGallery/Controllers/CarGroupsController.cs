using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Car.DataLayer.Context;
using Car.DataLayer.Entities;
using Car.DataLayer.Services.Interfaces;

namespace CarGallery.Controllers
{
    public class CarGroupsController : Controller
    {
        private ICarService _carService;

        public CarGroupsController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: CarGroups
        public IActionResult Index()
        {
            return View(_carService.GetAllCarGroup());
        }

 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CarGroup carGroup)
        {
            if (ModelState.IsValid)
            {
                _carService.AddGroup(carGroup);
                return RedirectToAction(nameof(Index));
            }
           
            return View(carGroup);
        }


        public IActionResult Edit(int?id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carGroup = _carService.GetBuId(id.Value);
            if (carGroup == null)
            {
                return NotFound();
            }
            return View(carGroup);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CarGroup carGroup)
        {
            

            if (ModelState.IsValid)
            {
                _carService.UpdateGroup(carGroup);
                return RedirectToAction(nameof(Index));
            }
            return View(carGroup);
           
        }

        
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carGroup = _carService.GetBuId(id);
            if (carGroup == null)
            {
                return NotFound();
            }
            _carService.DeleteGroup(carGroup);

            return RedirectToAction(nameof(Index));
        }

       
    }
}
