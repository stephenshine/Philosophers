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
            AutomaticMigrationsEnabled = false;
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
                    Area = "Logic",
                    Description = "Here's some text about Bertrand Russell"
                },
                new Philosopher
                {
                    FirstName = "Immanuel",
                    LastName = "Kant",
                    DateOfBirth = DateTime.Parse("1724-04-22"),
                    DateOfDeath = DateTime.Parse("1804-02-12"),
                    Nationality = "German",
                    Area = "Metaphysics",
                    Description = "Here's some text about Immanuel Kant"
                },
                new Philosopher
                {
                    FirstName = "John",
                    LastName = "Rawls",
                    DateOfBirth = DateTime.Parse("1921-02-21"),
                    DateOfDeath = DateTime.Parse("2002-11-24"),
                    Nationality = "American",
                    Area = "Political philosophy",
                    Description = "Here's some text about John Rawls"
                });
        }
    }
}
