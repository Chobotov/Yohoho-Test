using UnityEngine;
using YohohoChobotov.Game.Stack;

namespace YohohoChobotov.Game.Player
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Moveble))]
    [RequireComponent(typeof(Rotation))]
    public class UnitView : MonoBehaviour
    {
        [SerializeField] private UnitInventory unitInventory;
        [SerializeField] private Animator animator;

        public UnitInventory UnitInventory => unitInventory;
        public Moveble Moveble { get; private set; }
        public Rotation Rotation { get; private set; }
        public Animator Animator => animator;

        private void Awake()
        {
            Moveble = GetComponent<Moveble>();
            Rotation = GetComponent<Rotation>();
        }
    }
}