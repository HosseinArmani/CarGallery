using Car.DataLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarGallery.Components
{
    public class AgencyCompnetntcs:ViewComponent
    {
        private ICarService _carService;
        public AgencyCompnetntcs(ICarService carService)
        {
            _carService = carService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("Agency", _carService.GetAllAgency()));
        }
    }
}
