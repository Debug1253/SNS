using UnityEngine;
using sns.InputEvent;

using UniRx;

namespace sns.Player
{
    [RequireComponent(typeof(PlayerView))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerPresenter : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 100f;
        [SerializeField] private float jumpPower = 300f;

        private PlayerModel Model { get; set; }
        private PlayerView View { get { return GetComponent<PlayerView>(); } }

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            var rigid = GetComponent<Rigidbody2D>();
            Model = new PlayerModel(rigid, moveSpeed, jumpPower);

            InitEventHandler();
        }

        private void InitEventHandler()
        {
            View.OnHorizontal.Subscribe(x => Model.Move(x)).AddTo(this);
            View.OnJump.Where(onJump => onJump).Subscribe(_ => Model.Jump()).AddTo(this);
        }
    }
}