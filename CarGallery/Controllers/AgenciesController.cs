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
    public class AgenciesController : Controller
    {
        private ICarService _carService;

        public AgenciesController(ICarService carService)
        {
            _carService = carService;
        }


        public IActionResult Index()
        {
            return View(_carService.GetAllAgency());
        }

       
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Agency agency)
        {
            if (ModelState.IsValid)
            {
                _carService.AddAgency(agency);
                return RedirectToAction(nameof(Index));
            }

            return View(agency);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agency = _carService.GetByAgencyId(id.Value);
            if (agency == null)
            {
                return NotFound();
            }
            return View(agency);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Agency agency)
        {


            if (ModelState.IsValid)
            {
                _carService.UpdateAgency(agency);
                return RedirectToAction(nameof(Index));
            }
            return View(agency);

        }


        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agency = _carService.GetByAgencyId(id);
            if (agency == null)
            {
                return NotFound();
            }
            _carService.DeleteAgency(agency);

            return RedirectToAction(nameof(Index));
        }
    }
}
