using UniRx;

namespace YohohoChobotov.Services
{
    public interface IScoreService
    {
        IReadOnlyReactiveProperty<int> Score { get; }

        void SetScore(int score);
        void ClearScore();
    }
}