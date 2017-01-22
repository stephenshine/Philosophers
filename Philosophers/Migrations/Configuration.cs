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
                    Description = "Here's some text about Bertrand Russell",
                    ImgURL = "http://atheistfoundation.org.au/assets/Bertrand_Russell.jpg"
                },
                new Philosopher
                {
                    FirstName = "Immanuel",
                    LastName = "Kant",
                    DateOfBirth = DateTime.Parse("1724-04-22"),
                    DateOfDeath = DateTime.Parse("1804-02-12"),
                    NationalityID = 3,
                    AreaID = 2,
                    Description = "Here's some text about Immanuel Kant",
                    ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/43/Immanuel_Kant_(painted_portrait).jpg/220px-Immanuel_Kant_(painted_portrait).jpg"
                },
                new Philosopher
                {
                    FirstName = "John",
                    LastName = "Rawls",
                    DateOfBirth = DateTime.Parse("1921-02-21"),
                    DateOfDeath = DateTime.Parse("2002-11-24"),
                    NationalityID = 9,
                    AreaID = 3,
                    Description = "Here's some text about John Rawls",
                    ImgURL = "https://upload.wikimedia.org/wikipedia/en/3/3d/John_Rawls.jpg"
                },
                new Philosopher
                {
                    FirstName = "Rene",
                    LastName = "Descartes",
                    DateOfBirth = DateTime.Parse("1596-03-31"),
                    DateOfDeath = DateTime.Parse("1650-02-11"),
                    NationalityID = 4,
                    AreaID = 2,
                    Description = "Here's some text about Rene Descartes",
                    ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/73/Frans_Hals_-_Portret_van_Ren%C3%A9_Descartes.jpg/240px-Frans_Hals_-_Portret_van_Ren%C3%A9_Descartes.jpg"
                },
                new Philosopher
                {
                    FirstName = "David",
                    LastName = "Chalmers",
                    DateOfBirth = DateTime.Parse("1966-04-20"),
                    NationalityID = 10,
                    AreaID = 5,
                    Description = "Here's some text about David Chalmers",
                    ImgURL = "https://pi.tedcdn.com/r/pe.tedcdn.com/images/ted/fdb78c60dfa7d88ebab44c5bc169ca34fae90b0b_254x191.jpg?"
                },
                new Philosopher 
                {
                    FirstName = "John",
                    LastName = "Locke",
                    DateOfBirth = DateTime.Parse("1632-08-29"),
                    DateOfDeath = DateTime.Parse("1704-10-28"),
                    NationalityID = 1,
                    AreaID = 2,
                    Description = "Here's some text about John Locke",
                    ImgURL = "https://s-media-cache-ak0.pinimg.com/originals/12/b3/37/12b3376971e38954f462bac84b23cf12.jpg"
                },
                new Philosopher
                {
                    FirstName = "Jean-Paul",
                    LastName = "Sartre",
                    DateOfBirth = DateTime.Parse("1905-06-21"),
                    DateOfDeath = DateTime.Parse("1980-04-15"),
                    NationalityID = 4,
                    AreaID = 4,
                    Description = "Here's some text about John-Paul Sartre",
                    ImgURL = "https://upload.wikimedia.org/wikipedia/commons/e/e9/Jean_Paul_Sartre_1965.jpg"
                },
                new Philosopher
                {
                    FirstName = "Thomas",
                    LastName = "Hobbes",
                    DateOfBirth = DateTime.Parse("1588-04-05"),
                    DateOfDeath = DateTime.Parse("1670-12-04"),
                    NationalityID = 1,
                    AreaID = 3,
                    Description = "Here's some text about Thomas Hobbes",
                    ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d8/Thomas_Hobbes_(portrait).jpg/220px-Thomas_Hobbes_(portrait).jpg"
                },
                new Philosopher
                {
                    FirstName = "Friedrich",
                    LastName = "Nietzsche",
                    DateOfBirth = DateTime.Parse("1844-10-15"),
                    DateOfDeath = DateTime.Parse("1900-08-25"),
                    NationalityID = 8,
                    AreaID = 2,
                    Description = "Here's some text about Friedrich Nietzsche",
                    ImgURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/Nietzsche187a.jpg/220px-Nietzsche187a.jpg"
                }
                );

            context.Areas.AddOrUpdate(a => a.Name,
                new Area { Name = "Logic", Description = "The systematic study of the form of arguments." },
                new Area { Name = "Metaphysics", Description = "Investigates the fundamental nature of being and the world." },
                new Area { Name = "Political philosophy", Description = "The study of politics, liberty and justice and the enforcement of the legal code." },
                new Area { Name = "Existenalism", Description = "The idea that philosophy involves acting, feeling and the living individual." }, 
                new Area { Name = "Philosophy of the mind", Description = "The study of the mind, mental events, mental functions and consciousness in relation to the physical body." },
                new Area { Name = "Moral philosophy", Description = "Systemizing, defending and recommending concepts of right and wrong conduct." },
                new Area { Name = "Aesthetics", Description = "Deals with the creation and appreciation of art and beauty." },
                new Area { Name = "Social philosophy", Description = "The study of social behaviour and interpretations of society and social institutions." },
                new Area { Name = "Epistemology", Description = "The study of the nature of knowledge, the rationality of belief, and justification." });

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
