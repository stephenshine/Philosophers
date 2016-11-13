using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Philosophers.Models.Abstract
{
    public interface IPhilosopherRepository
    {
        IEnumerable<Philosopher> Philosophers { get; }
        IEnumerable<Area> Areas { get; }
        IEnumerable<Nationality> Nationalities { get; }

        void AddPhilosopher(Philosopher philosopher);
    }
}