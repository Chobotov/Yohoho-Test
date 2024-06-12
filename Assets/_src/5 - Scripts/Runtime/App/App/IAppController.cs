using Cysharp.Threading.Tasks;

namespace YohohoChobotov.App
{
    public interface IAppController
    {
        UniTask InitGame();
        void LaunchGame();
        void Quit();
    }
}