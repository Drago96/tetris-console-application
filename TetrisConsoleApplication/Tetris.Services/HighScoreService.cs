using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Tetris.Data;
using Tetris.Models.Entities;

namespace Tetris.Services
{
    public class HighScoreService
    {
        public ICollection<HighScore> GetTopTenHighScores()
        {
            using (var context = new TetrisDbContext())
            {
                var highscores = context.HighScores.OrderByDescending(h => h.Points).Include(h => h.User).Take(10).ToList();
                return highscores;
            }
        }
    }
}