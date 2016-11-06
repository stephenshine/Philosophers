using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Philosophers.Models
{
    public class Book
    {
        public int BookID { get; set; }

        [StringLength(100)]
        public string Title { get; set; }
        public int AreaID { get; set; }

        public virtual Area Area { get; set; }
    }
}