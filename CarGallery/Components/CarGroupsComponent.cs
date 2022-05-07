using Car.DataLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarGallery.Components
{
    public class CarGroupsComponent:ViewComponent
    {
        private ICarService _carService;
        public CarGroupsComponent(ICarService carService)
        {
            _carService = carService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("CarGroup",_carService.GetAllCarGroup()));
        }
    }
}
