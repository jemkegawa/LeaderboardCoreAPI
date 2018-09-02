using Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Data.DAL
{
    interface IScoreDAL
    {
        void AddScore(Score score);
        IEnumerable<Score> GetHighScores(int numResults);
        IEnumerable<Score> GetHighScores(int numResults, int startPosition);
    }

    public class ScoreDAL : IScoreDAL
    {
        private LeaderboardContext _context;
        private PersonDAL _personDAL;
        
        public ScoreDAL(LeaderboardContext context)
        {
            _context = context;
            _personDAL = new PersonDAL(context);
        }

        public IEnumerable<Score> GetHighScores(int numResults)
        {
            return _context.Scores
                .Include(s => s.Person)
                .OrderByDescending(s => s.Value)
                .Take(numResults)
                .ToList();
        }

        public IEnumerable<Score> GetHighScores(int numResults, int startPosition)
        {
            return _context.Scores
                .Include(s => s.Person)
                .OrderByDescending(s => s.Value)
                .Skip(startPosition)
                .Take(numResults)
                .ToList();
        }

        public void AddScore(Score score)
        {
            if (score == null)
                return;

            _context.Scores.Add(score);

            _context.SaveChanges();
        }
    }
}
