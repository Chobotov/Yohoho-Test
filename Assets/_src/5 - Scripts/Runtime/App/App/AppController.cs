using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace YohohoChobotov.App
{
    public sealed class AppController : MonoBehaviour
    {
        [SerializeField] private AppLifetimeScope gameScope;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private async void Start()
        {
            await InitGame();

            LaunchGame();
        }

        private async UniTask InitGame()
        {
            gameScope.Build();
        }

        private void LaunchGame()
        {
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}