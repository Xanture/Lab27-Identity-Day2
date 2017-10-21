using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab27_brian.Models
{
    public class LocationPost
    {
        [Key]
        public int LocationID { get; set; }
        public string Review { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }
        public bool Contact { get; set; }
    }
}
