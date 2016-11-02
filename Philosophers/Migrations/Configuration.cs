namespace Philosophers.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Philosophers.Models.PhilosopherDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Philosophers.Models.PhilosopherDBContext context)
        {
            context.Philosophers.AddOrUpdate(p => p.LastName,
                new Philosopher
                {
                    FirstName = "Bertrand",
                    LastName = "Russell",
                    DateOfBirth = DateTime.Parse("1872-05-18"),
                    DateOfDeath = DateTime.Parse("1970-02-02"),
                    Nationality = "English",
                    AreaID = 1,
                    Description = "Here's some text about Bertrand Russell"
                },
                new Philosopher
                {
                    FirstName = "Immanuel",
                    LastName = "Kant",
                    DateOfBirth = DateTime.Parse("1724-04-22"),
                    DateOfDeath = DateTime.Parse("1804-02-12"),
                    Nationality = "German",
                    AreaID = 2,
                    Description = "Here's some text about Immanuel Kant"
                },
                new Philosopher
                {
                    FirstName = "John",
                    LastName = "Rawls",
                    DateOfBirth = DateTime.Parse("1921-02-21"),
                    DateOfDeath = DateTime.Parse("2002-11-24"),
                    Nationality = "American",
                    AreaID = 3,
                    Description = "Here's some text about John Rawls"
                }
                //new Philosopher
                //{
                //    FirstName = "Rene",
                //    LastName = "Descartes",
                //    DateOfBirth = DateTime.Parse("1596-02-31"),
                //    DateOfDeath = DateTime.Parse("1650-02-11"),
                //    Nationality = "French",
                //    AreaID = 2,
                //    Description = "Here's some text about Rene Descartes"
                //}
                );

            context.Areas.AddOrUpdate(a => a.Name,
                new Area { Name = "Logic" },
                new Area { Name = "Metaphysics" },
                new Area { Name = "Political philosophy" });
        }
    }
}
