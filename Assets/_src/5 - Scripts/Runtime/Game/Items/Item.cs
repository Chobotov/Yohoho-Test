using UnityEngine;

namespace YohohoChobotov.Game.Items
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private Transform render;

        public Transform Render => render;
    }
}