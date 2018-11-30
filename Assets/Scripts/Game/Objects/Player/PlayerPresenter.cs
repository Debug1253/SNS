using System;
using UnityEngine;

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
            ObserveIsGround().Where(isGround => isGround).Subscribe(_ => Model.Landing()).AddTo(this);
        }

        private IObservable<bool> ObserveIsGround()
        {
            var adjustment = 1; // NOTE: 자기자신을 감지하는 것을 방지
            var charaHalfHeightWithAdjustment = GetComponent<BoxCollider2D>().size.y * 0.5f + adjustment;
            return Observable.EveryUpdate()
                .Select(_ => 
                {
                var footPosition = transform.position + Vector3.down * charaHalfHeightWithAdjustment;
                    var hit = Physics2D.Raycast(footPosition, Vector2.down);

                    return Vector2.Distance(hit.point, footPosition) <= 0;
                }).DistinctUntilChanged();
        }
    }
}