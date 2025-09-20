using UnityEngine;

namespace YohohoChobotov.Game
{
    public interface IFactory<T> where T : MonoBehaviour
    {
        
        T Create(Vector3 position);
    }
}