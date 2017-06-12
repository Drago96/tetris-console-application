namespace Tetris.Models.Entities
{
    using System;
    using Microsoft.Build.Framework;

    public class HighScore
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public long Points { get; set; }

        public virtual User User { get; set; }
    }
}