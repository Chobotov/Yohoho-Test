using UniRx;

namespace YohohoChobotov.Services
{
    public class ScoreService : IScoreService
    {
        private IntReactiveProperty score = new();

        public IReadOnlyReactiveProperty<int> Score => score;

        public void SetScore(int score)
        {
            this.score.Value = score;
        }

        public void ClearScore()
        {
            score.Value = 0;
        }
    }
}