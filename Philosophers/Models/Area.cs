using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Philosophers.Models
{
    public class Area
    {
        public int AreaId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Philosopher> Philosophers { get; set; }
    }
}