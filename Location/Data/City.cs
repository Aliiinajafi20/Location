using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Location.Data
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        public String CityName { get; set; }

        [ForeignKey("AriaId")]
        public Area Area { get; set; }
        public int AriaId { get; set; }
    }
}
