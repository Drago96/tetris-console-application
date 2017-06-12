namespace Tetris.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Tetris.Models.Entities;

    public class TetrisDbContext : DbContext
    {

        public TetrisDbContext()
            : base("name=TetrisDbContext")
        {
        }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<HighScore> HighScores { get; set; }
    }
}