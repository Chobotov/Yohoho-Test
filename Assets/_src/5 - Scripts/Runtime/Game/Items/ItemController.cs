using UnityEngine;

namespace YohohoChobotov.Game.Items
{
    public class ItemController : MonoBehaviour
    {
        [SerializeField] private Transform render;

        public Transform Render => render;
    }
}