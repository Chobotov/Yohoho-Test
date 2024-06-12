using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace YohohoChobotov.App
{
    /// <summary>
    /// Единая точка входа в проект
    /// Отсюда начинается инициализация необходимых модулей/сервисов и т.д.
    /// Загрузка начальной сцены и/или экрана
    /// </summary>
    public sealed class AppController : MonoBehaviour, IAppController
    {
        [SerializeField] private GameLifetimeScope gameScope;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private async void Start()
        {
            Debug.Log($"System : Start Init");

            await InitGame();

            Debug.Log($"System : End Init");

            await LoadGameScene();

            LaunchGame();
        }

        public async UniTask InitGame()
        {
            gameScope.Build();
        }

        public void LaunchGame()
        {
            LoadGameScene();
        }

        public void Quit()
        {
            Application.Quit();
        }

        private async UniTask LoadGameScene()
        {
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }
    }
}