using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Philosophers.Models
{
    public class Area
    {
        public int AreaId { get; set; }
        
        [Display(Name = "Area")]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Philosopher> Philosophers { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
