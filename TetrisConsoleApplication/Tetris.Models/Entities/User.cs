namespace Tetris.Models.Entities
{
    using System.Collections.Generic;
    using Microsoft.Build.Framework;


    public class User
    {
        private ICollection<HighScore> _highscores;

        public User()
        {
            this._highscores = new HashSet<HighScore>();
        }

        public int Id { get; set; }

        [Required]

        public string Name { get; set; }

        public virtual ICollection<HighScore> HighScores
        {
            get { return this._highscores; }
            set { this._highscores = value; }
        }
    }
}