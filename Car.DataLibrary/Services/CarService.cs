using Car.DataLayer.Context;
using Car.DataLayer.Entities;
using Car.DataLayer.Services.Interfaces;
using Car.DataLayer.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.DataLayer.Services
{
  public  class CarService:ICarService
    {
        private CarGalleryContext _context;
        public CarService(CarGalleryContext context)
        {
            _context = context;
        }
        public CarGroup GetBuId(int groupid)
        {
           return _context.CarGroups.Find(groupid);
        }
        public void AddGroup(CarGroup carGroup)
        {
            _context.CarGroups.Add(carGroup);
            _context.SaveChanges();
        }
        public bool UpdateGroup(CarGroup carGroup)
        {
            try
            {
                _context.Entry(carGroup).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public bool DeleteGroup(CarGroup carGroup)
        {
            try
            {
                _context.Entry(carGroup).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            catch 
            {

                return false;
            }
        }

        public List<CarGroup> GetAllCarGroup()
        {
            return _context.CarGroups.ToList();
        }

       

        public List<ShowCarListItemViewModel> GetCar(List<int> SelectGroups = null)
        {
            IQueryable<DataLayer.Entities.Car> Cars = _context.Cars;
            if(SelectGroups!=null&&SelectGroups.Any())
            {
                foreach (var groupid in SelectGroups)
                {
                    Cars = Cars.Where(c => c.GroupId == groupid);
                }
            }
            return Cars.Include(c => c.CarPrice).Select(c => new ShowCarListItemViewModel()
            {
                CarId = c.CarId,
                Name = c.Name,
                Model = c.Model,
                SalesPrice = c.CarPrice.SalesPrice

            }).ToList();
        }


        public Entities.Car GetCarDetail(int carId)
        {
            return _context.Cars.Include(c => c.CarBodyInformation)
              .Include(c => c.CarEngineInformation)
              .Include(c => c.CarGroup).FirstOrDefault(c => c.CarId == carId);
        }

        public List<SelectListItem> GetSelectGroupForCar()
        {
            return _context.CarGroups.Select(c => new SelectListItem
            {
                Text = c.TitleGroup,
                Value = c.GroupId.ToString()
            }).ToList();
        }
        public List<SelectListItem> GetSelectBodyInformationForCar()
        {
            return _context.CarBodyInformations.Select(c => new SelectListItem
            {
                Text = c.BodyType,
                Value = c.CarBodyId.ToString()
            }).ToList();
        }

        public List<SelectListItem> GetSelectEngineInformationForCar()
        {
            return _context.CarEngineInformations.Select(c => new SelectListItem
            {
                Text=c.EngineType,
                Value=c.CarEnginId.ToString()
            }).ToList();
        }

        public List<SelectListItem> GetSelectPriceForCar()
        {
            return _context.CarPrices.Select(c => new SelectListItem
            {
                Text = c.SalesPrice.ToString(),
                Value = c.PriceId.ToString()
            }).ToList();
        }
        public void AddCar(Entities.Car car)
        {
            _context.Add(car);
            _context.SaveChanges();

        }

        public Entities.Car GetCarById(int carId)
        {

            return _context.Cars.Find(carId);
        }

        public bool UpdateCar(Entities.Car car)
        {
            try
            {
                _context.Entry(car).State = EntityState.Modified;
                _context.SaveChanges();
                    
                return true;
            }
            catch 
            {

                return false;
            }
        }

        public bool DeleteCar(Entities.Car car)
        {
            try
            {
                _context.Entry(car).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            catch 
            {

                return false;
            }
        }

        public List<Agency> GetAllAgency()
        {
            return _context.Agencies.ToList();
        }

        public Agency GetByAgencyId(int Agencyid)
        {
            return _context.Agencies.Find(Agencyid);
                
        }

        public void AddAgency(Agency agency)
        {

            _context.Agencies.Add(agency);
            _context.SaveChanges();

        }

        public bool UpdateAgency(Agency agency)
        {
            try
            {
                _context.Entry(agency).State = EntityState.Modified;
                _context.SaveChanges();

                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool DeleteAgency(Agency agency)
        {
            try
            {
                _context.Entry(agency).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }

     
    }
}
