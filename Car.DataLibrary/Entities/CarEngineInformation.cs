using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.DataLayer.Entities
{
   public class CarEngineInformation
    {
        [Key]
        public int CarEnginId  { get; set; }
        [Display(Name ="حجم موتور")]
        [Required]
        [MaxLength(200)]
        public string EngineDisplacement { get; set; }

        [Display(Name = "نوع موتور")]
        [Required]
        [MaxLength(200)]
        public string EngineType { get; set; }
        [Display(Name = "تعداد سیلندر")]
        [Required]
        [MaxLength(50)]
        public int cylindersCount { get; set; }
        [Display(Name = "تعداد سوپاپ")]
        [Required]
        [MaxLength(50)]
        public int SoupapeCount { get; set; }


        public List<Car> Cars { get; set; }

    }
}
