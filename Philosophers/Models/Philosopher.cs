using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Philosophers.Models
{
    public class Philosopher
    {
        public int PhilosopherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }
        public string Area { get; set; }
        public string Nationality { get; set; }
        public string Description { get; set; }
    }

    public class PhilosopherDBContext : DbContext
    {
        public DbSet<Philosopher> Philosophers { get; set; }
    }
}