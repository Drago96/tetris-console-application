namespace Tetris.Data
{
    using System.Data.Entity;
    using Tetris.Data.Migrations;
    using Tetris.Models.Entities;

    public class TetrisDbContext : DbContext
    {
        public TetrisDbContext()
            // : base("name=TetrisDbContext")
            : base(@"data source=(LocalDb)\MSSQLLocalDB;initial catalog=Tetris.Data.TetrisDbContext;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")

        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TetrisDbContext, Configuration>());
        }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<HighScore> HighScores { get; set; }
    }
}