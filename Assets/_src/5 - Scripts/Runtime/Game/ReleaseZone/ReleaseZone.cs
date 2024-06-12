using UnityEngine;
using VContainer;
using YohohoChobotov.Game.Stack;
using YohohoChobotov.Services;

namespace YohohoChobotov.Game.ReleaseZone
{
    public class ReleaseZone : MonoBehaviour
    {
        private IScoreService scoreService;

        [Inject]
        public void Inject(IScoreService scoreService)
        {
            this.scoreService = scoreService;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<StackController>(out var stack))
            {
                scoreService.SetScore(scoreService.Score.Value + stack.Count);

                stack.Clear();
            }
        }
    }
}