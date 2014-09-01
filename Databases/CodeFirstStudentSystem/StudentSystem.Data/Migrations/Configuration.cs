namespace StudentSystem.Data.Migrations
{
    using StudentSystem.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        private static Random randomGenerator = new Random();

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            var randomSeedNumber = randomGenerator.Next();

            context.Students.Add(
                new Student()
                {
                    Name = "Seeded",
                    Number = randomSeedNumber
                });

            context.SaveChanges();
        }
    }
}
