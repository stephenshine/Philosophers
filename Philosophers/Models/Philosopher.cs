using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Philosophers.Models
{
    public class Philosopher
    {
        public int PhilosopherID { get; set; }

        [Required, Display(Name = "First Name"), StringLength(25, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name"), StringLength(30, MinimumLength = 4)]
        public string LastName { get; set; }

        [Required, Display(Name = "Date of birth"), DataType(DataType.Date)]
        [Column(TypeName="datetime2")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Date of death")]
        [DataType(DataType.Date)]
        [Column(TypeName = "datetime2")]
        public DateTime DateOfDeath { get; set; }

        [Required, Display(Name = "Area")]
        public int AreaID { get; set; }

        [Required, Display(Name = "Nationality")]
        public int NationalityID { get; set; }

        [Required, StringLength(500, MinimumLength = 20)]
        public string Description { get; set; }

        public virtual Area Area { get; set; }
        public virtual Nationality Nationality { get; set; }

        [Display(Name ="Full name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public string ImgUrl
        {
            get { return PhilosopherID + "-" + LastName + ".jpg"; }
        }
    }
}