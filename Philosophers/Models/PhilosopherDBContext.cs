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
        public DbSet<Area> Areas { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasOptional(b => b.Philosopher)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}