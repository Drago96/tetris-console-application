using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tetris.Models.Entities
{
    using System;
    using Microsoft.Build.Framework;

    public class HighScore
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public long Points { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        
        public virtual User User { get; set; }
    }
}