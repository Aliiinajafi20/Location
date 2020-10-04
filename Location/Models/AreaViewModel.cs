using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Location.Models
{
    public class DetailsAreaViewModel
    {
        [Display(Name = "کد استان")]
        public int AriaId { get; set; }
        [Display(Name = "نام استان")]
        public string AriaName { get; set; }
    }
    public class CreateAreaViewModel
    {
        [Required]
        public string AriaName { get; set; }
    }
}
