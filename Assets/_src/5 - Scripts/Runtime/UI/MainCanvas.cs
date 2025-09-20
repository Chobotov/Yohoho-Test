using TMPro;
using UniRx;
using UnityEngine;
using VContainer;
using YohohoChobotov.Services;

namespace YohohoChobotov.UI
{
    public class MainCanvas : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI stackCount;
        [SerializeField] private TextMeshProUGUI score;

        private IScoreService scoreService;

        [Inject]
        public void Inject(IScoreService scoreService)
        {
            this.scoreService = scoreService;

            InitSubs();
        }

        private void InitSubs()
        {
            scoreService.Score
                .Subscribe(SetScore)
                .AddTo(this);
        }

        private void SetStackCount(int count)
        {
            stackCount.text = $"{count}/";
        }

        private void SetScore(int count)
        {
            score.text = $"{count}";
        }
    }
}