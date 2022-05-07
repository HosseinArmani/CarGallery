using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.DataLayer.Entities
{
  public class CarPrice
    {
        [Key]
        public int PriceId { get; set; }
        [Display(Name ="قیمت تمام شده")]
        [Required]
        [MaxLength(200)]
        public int PrimeCost { get; set; }
        [Display(Name = "قیمت فروش")]
        [Required]
        [MaxLength(200)]
        public int SalesPrice { get; set; }

        public List<Car> Cars { get; set; }
    }
}
