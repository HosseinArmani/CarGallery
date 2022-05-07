using Car.DataLayer.Entities;
using Car.DataLayer.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Car.DataLayer.Services.Interfaces
{
   public interface ICarService
    {
        #region Group

        List<CarGroup> GetAllCarGroup();
        CarGroup GetBuId(int groupid);
        void AddGroup(CarGroup carGroup);
        bool UpdateGroup(CarGroup carGroup);
        bool DeleteGroup(CarGroup carGroup);
       
        #endregion

        #region Car
        List<ShowCarListItemViewModel> GetCar(List<int> SelectGroups=null);
        DataLayer.Entities.Car GetCarDetail(int carId);
        DataLayer.Entities.Car GetCarById(int carId);
        void AddCar(Car.DataLayer.Entities.Car car);
        bool UpdateCar(Car.DataLayer.Entities.Car car);
        bool DeleteCar(Car.DataLayer.Entities.Car car);
        List<SelectListItem> GetSelectGroupForCar();
        List<SelectListItem> GetSelectBodyInformationForCar();
        List<SelectListItem> GetSelectEngineInformationForCar();
        List<SelectListItem> GetSelectPriceForCar();

        #endregion
        #region Agency
   
        List<Agency> GetAllAgency();
        Agency GetByAgencyId(int Agencyid);
        void AddAgency(Agency agency);
        bool UpdateAgency(Agency agency);
        bool DeleteAgency(Agency agency);

        #endregion
    }
}
