using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Philosophers.Models
{
    public partial class Philosopher
    {
        [Key]
        public int PhilosopherID { get; set; }

        [Required, Display(Name = "First Name"), StringLength(25, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name"), StringLength(30, MinimumLength = 4)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "A date of birth is required"), Display(Name = "Date of birth"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column(TypeName="datetime2")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Date of death"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime? DateOfDeath { get; set; }

        [Required(ErrorMessage = "An Area is required"), Display(Name = "Area")]
        public int AreaID { get; set; }

        [Required(ErrorMessage = "A Nationality is required"), Display(Name = "Nationality")]
        public int NationalityID { get; set; }

        [Required, StringLength(500, MinimumLength = 20)]
        public string Description { get; set; }

        public virtual Area Area { get; set; }
        public virtual Nationality Nationality { get; set; }
    }
}