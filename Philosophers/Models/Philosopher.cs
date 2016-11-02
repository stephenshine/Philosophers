using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Philosophers.Models
{
    public class Philosopher
    {
        public int PhilosopherID { get; set; }

        [Display(Name = "First Name")]
        [StringLength(25, MinimumLength = 3)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(30, MinimumLength = 4)]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        [Column(TypeName="datetime2")]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Date of death")]
        [DataType(DataType.Date)]
        [Column(TypeName = "datetime2")]
        public DateTime DateOfDeath { get; set; }

        [Required]
        public string Area { get; set; }

        [Required]
        public string Nationality { get; set; }

        [StringLength(500, MinimumLength = 20)]
        [Required]
        public string Description { get; set; }
    }

    public class PhilosopherDBContext : DbContext
    {
        public DbSet<Philosopher> Philosophers { get; set; }
    }
}