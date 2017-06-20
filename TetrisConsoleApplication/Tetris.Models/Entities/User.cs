namespace Tetris.Models.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        private ICollection<HighScore> _highscores;

        public User()
        {
            this._highscores = new HashSet<HighScore>();
        }

        public User(string name)
            : this()
        {
            this._highscores = new HashSet<HighScore>();
            this.Name = name;
        }

        [Key]
        public int Id { get; set; }

        [Microsoft.Build.Framework.Required]
        public string Name { get; set; }

        public virtual ICollection<HighScore> HighScores
        {
            get { return this._highscores; }
            set { this._highscores = value; }
        }
    }
}