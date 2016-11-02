﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Philosophers.Models
{
    public class PhilosopherDBContext : DbContext
    {
        public DbSet<Philosopher> Philosophers { get; set; }
    }
}