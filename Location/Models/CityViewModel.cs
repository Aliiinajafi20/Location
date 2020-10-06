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

        public DetailsCountryViewModel Country { get; set; }
        [Display(Name = "کد کشور")]
        public int CountryId { get; set; }
        [Display(Name = "نام کشور")]
        public string CountryName { get; set; }

        public DetailsAreaViewModel Area { get; set; }
        [Display(Name = "کد استان")]
        public int AriaId { get; set; }
        [Display(Name = "نام استان")]
        public string AriaName { get; set; }
    }
    public class CreatCityViewModel
    {
        [Required]
        public string CityName { get; set; }
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public int AriaId { get; set; }
        public string AriaName { get; set; }

    }
}
