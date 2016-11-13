using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Philosophers.Models.Abstract;

namespace Philosophers.Models
{
    public class EFPhilosopherRepository : IPhilosopherRepository
    {
        private PhilosopherDBContext context = new PhilosopherDBContext();

        public IEnumerable<Philosopher> Philosophers
        {
            get
            {
                return context.Philosophers
                    .Include("Area").Include("Nationality");
            }
        }

        public IEnumerable<Area> Areas
        {
            get
            {
                return context.Areas
                    .Include("Philosophers");
            }
        }

        public IEnumerable<Nationality> Nationalities
        {
            get
            {
                return context.Nationalities
                    .Include("Philosophers");
            }
        }

        public void AddPhilosopher(Philosopher philosopher)
        {
            context.Philosophers.Add(philosopher);
            context.SaveChanges();
        }
    }
}