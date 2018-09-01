using Data.DataContext;
using Models;

namespace Data.DAL
{
    interface IScoreDAL
    {
        void AddScore(Score score);
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

        public void AddScore(Score score)
        {
            if (score == null)
                return;

            _context.Scores.Add(score);

            _context.SaveChanges();
        }
    }
}
