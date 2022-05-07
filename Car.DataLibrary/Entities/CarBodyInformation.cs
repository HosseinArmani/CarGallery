using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.DataLayer.Entities
{
    public class CarBodyInformation
    {
        [Key]
        public int CarBodyId { get; set; }
        [Display(Name = "نوع بدنه")]
        [Required]
        [MaxLength(200)]
        public string BodyType { get; set; }
        [Display(Name = "وزن")]
        [Required]
        [MaxLength(50)]
        public int Weight { get; set; }
        [Display(Name = "تعداد درب")]
        [Required]
        [MaxLength(50)]
        public int DoorsCount { get; set; }

        public List<Car> Cars { get; set; }

    }
}
