using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Philosophers.Models
{
    public class Nationality
    {
        public int NationalityID { get; set; }

        [Display(Name = "Nationality")]
        public string Name { get; set; }

        public virtual ICollection<Philosopher> Phliosophers { get; set; }
    }
}