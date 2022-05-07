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
    public class CarsController : Controller
    {
        private ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: Cars
        public IActionResult Index()
        {
            
            return View(_carService.GetCar());
        }

        public IActionResult Create()
        {
            ViewData["CarBodyId"] = new SelectList(_carService.GetSelectBodyInformationForCar(), "Value", "Text");
            ViewData["CarEngineId"] = new SelectList(_carService.GetSelectEngineInformationForCar(), "Value", "Text");
            ViewData["GroupId"] = new SelectList(_carService.GetSelectGroupForCar(), "Value","Text");
            ViewData["PriceId"] = new SelectList(_carService.GetSelectPriceForCar(), "Value", "Text");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create(Car.DataLayer.Entities.Car car)
        {
            if (ModelState.IsValid)
            {
                _carService.AddCar(car);
                return RedirectToAction(nameof(Index));
            }

            return View(car);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _carService.GetCarById(id.Value);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["CarBodyId"] = new SelectList(_carService.GetSelectBodyInformationForCar(), "Value", "Text", car.CarBodyId);
            ViewData["CarEngineId"] = new SelectList(_carService.GetSelectEngineInformationForCar(), "Value", "Text",car.CarEngineId);
            ViewData["GroupId"] = new SelectList(_carService.GetSelectGroupForCar(), "Value", "Text", car.GroupId);
            ViewData["PriceId"] = new SelectList(_carService.GetSelectPriceForCar(), "Value", "Text");
            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( Car.DataLayer.Entities.Car car)
        {

            if (ModelState.IsValid)
            {

                _carService.UpdateCar(car);
                return RedirectToAction(nameof(Index));

            }
            
            return View(car);
        }

        
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _carService.GetCarById(id);

            if (car == null)
            {
                return NotFound();
            }
            _carService.DeleteCar(car);
            return RedirectToAction(nameof(Index));
        }

     

    }
}
