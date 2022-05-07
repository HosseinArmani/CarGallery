using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.DataLayer.ViewModel
{
 public  class ShowCarListItemViewModel
    {
        public  int CarId { get; set; }
        public string Name { get; set; }
        public int SalesPrice { get; set; }
        public string Model { get; set; }
    }
}
