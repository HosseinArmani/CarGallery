using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.DataLayer.Entities
{
   public class Car
    {
        [Key]
        public int CarId { get; set; }
        
        [Required]
        public int GroupId { get; set; }
        [Required]
        public int CarBodyId { get; set; }
        [Required]
        public int CarEngineId { get; set; }
        [Required]
        public int PriceId { get; set; }
        [Display(Name ="نام ماشین")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string Name{ get; set; }
        [Display(Name = "شرح ماشین")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }
        [Display(Name = "مدل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string Model { get; set; }
        [Display(Name = "رنگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string Color { get; set; }
        [Display(Name = "سال ساخت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50)]
        public string Year { get; set; }
        
        public int? AgencyId { get; set; }


        #region Rel

        [ForeignKey("GroupId")]
        public CarGroup CarGroup { get; set; }
        [ForeignKey("CarBodyId ")]
        public CarBodyInformation CarBodyInformation { get; set; }
        [ForeignKey("CarEngineId")]
        public CarEngineInformation CarEngineInformation { get; set; }
        [ForeignKey("PriceId ")]
        public CarPrice CarPrice { get; set; }
        [ForeignKey("AgencyId")]
        public Agency Agency { get; set; }
        #endregion

    }
}
