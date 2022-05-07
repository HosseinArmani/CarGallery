using Car.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.DataLayer.Context
{
   public class CarGalleryContext:DbContext
    {
        public CarGalleryContext(DbContextOptions<CarGalleryContext> options):base(options)
        {

        }
        public DbSet<CarGroup> CarGroups{ get; set; }
        public DbSet<DataLayer.Entities.Car> Cars{ get; set; }
        public DbSet<CarBodyInformation> CarBodyInformations { get; set; }
        public DbSet<CarEngineInformation> CarEngineInformations { get; set; }
        public DbSet<CarPrice> CarPrices{ get; set; }
        public DbSet<Agency> Agencies { get; set; }


    }
}
