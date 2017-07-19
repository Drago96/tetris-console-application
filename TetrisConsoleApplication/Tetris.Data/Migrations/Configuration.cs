namespace Tetris.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Tetris.Models.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<TetrisDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TetrisDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Users.AddOrUpdate(
                u => u.Name,
                new User("FirstUser"));
        }

        //private void CreateUser(TetrisDbContext context, string name)
        //{
        //    var user = new User(name);
        //    context.SaveChanges();
        //}
    }
}