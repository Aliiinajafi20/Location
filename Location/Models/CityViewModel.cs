using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Location.Models
{
    public class DetailsCityViewModel
    {
        [Display(Name = "کد شهر")]
        public int CityId { get; set; }
        [Display(Name = "نام شهر")]
        public string CityName { get; set; }
    }
    public class CreatCityViewModel
    {
        [Required]
        public string CityName { get; set; }

    }
}
