using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Philosophers.Models
{
    // partial class used to separate data model for DB from other attributes
    public partial class Philosopher
    {
        [Display(Name = "Full name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        //public string ImgUrl
        //{
        //    get { return PhilosopherID + "-" + LastName + ".jpg"; }
        //}

        public int calculateAge()
        {
            int age;
            if (DateOfDeath.HasValue)
            {
                age = DateOfDeath.Value.Year - DateOfBirth.Year;
                if (DateOfDeath.Value < DateOfBirth.AddYears(age))
                {
                    age--;
                }
            }
            else
            {
                age = DateTime.Now.Year - DateOfBirth.Year;
                if (DateTime.Now < DateOfBirth.AddYears(age))
                {
                    age--;
                }
            }
            return age;
        }
    }
}