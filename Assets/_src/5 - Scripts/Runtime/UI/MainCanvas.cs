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
        private IStackService stackService;

        [Inject]
        public void Inject(IScoreService scoreService, IStackService stackService)
        {
            this.scoreService = scoreService;
            this.stackService = stackService;

            InitSubs();
        }

        private void InitSubs()
        {
            scoreService.Score
                .Subscribe(SetScore)
                .AddTo(this);

            stackService.Items
                .ObserveCountChanged(notifyCurrentCount: true)
                .Subscribe(SetStackCount)
                .AddTo(this);
        }

        private void SetStackCount(int count)
        {
            stackCount.text = $"{count}/{stackService.GetMaxCount()}";
        }

        private void SetScore(int count)
        {
            score.text = $"{count}";
        }
    }
}