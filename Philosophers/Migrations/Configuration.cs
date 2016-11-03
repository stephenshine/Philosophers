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
                    NationalityID = 1,
                    AreaID = 1,
                    Description = "Here's some text about Bertrand Russell"
                },
                new Philosopher
                {
                    FirstName = "Immanuel",
                    LastName = "Kant",
                    DateOfBirth = DateTime.Parse("1724-04-22"),
                    DateOfDeath = DateTime.Parse("1804-02-12"),
                    NationalityID = 3,
                    AreaID = 2,
                    Description = "Here's some text about Immanuel Kant"
                },
                new Philosopher
                {
                    FirstName = "John",
                    LastName = "Rawls",
                    DateOfBirth = DateTime.Parse("1921-02-21"),
                    DateOfDeath = DateTime.Parse("2002-11-24"),
                    NationalityID = 9,
                    AreaID = 3,
                    Description = "Here's some text about John Rawls"
                },
                new Philosopher
                {
                    FirstName = "Rene",
                    LastName = "Descartes",
                    DateOfBirth = DateTime.Parse("1596-03-31"),
                    DateOfDeath = DateTime.Parse("1650-02-11"),
                    NationalityID = 4,
                    AreaID = 2,
                    Description = "Here's some text about Rene Descartes"
                },
                new Philosopher
                {
                    FirstName = "David",
                    LastName = "Chalmers",
                    DateOfBirth = DateTime.Parse("1966-04-20"),
                    NationalityID = 10,
                    AreaID = 5,
                    Description = "Here's some text about David Chalmers"
                }
                );

            context.Areas.AddOrUpdate(a => a.Name,
                new Area { Name = "Logic" },
                new Area { Name = "Metaphysics" },
                new Area { Name = "Political philosophy" },
                new Area { Name = "Existenalism" }, 
                new Area { Name = "Philosophy of the mind" },
                new Area { Name = "Moral philosophy" },
                new Area { Name = "Aesthetics" },
                new Area { Name = "Social philosophy" },
                new Area { Name = "Epistemology" });

            context.Nationalities.AddOrUpdate(n => n.Name, 
                new Nationality { Name = "English" },
                new Nationality { Name = "Scottish" },
                new Nationality { Name = "German" },
                new Nationality { Name = "French" },
                new Nationality { Name = "Greek" },
                new Nationality { Name = "Italian" },
                new Nationality { Name = "Spanish" },
                new Nationality { Name = "Russian" },
                new Nationality { Name = "American" },
                new Nationality { Name = "Australian" });
        }
    }
}
