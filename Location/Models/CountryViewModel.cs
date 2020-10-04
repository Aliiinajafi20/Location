using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Location.Models
{
    public class DetailsCountryViewModel
    {
        [Display(Name ="کد کشور")]
        public int CountryId { get; set; }
        [Display(Name = "نام کشور")]
        public string CountryName { get; set; }
    }

    public class CreateCountryViewModel
    {
        [Required]
        public string CountryName { get; set; }
    }
}
