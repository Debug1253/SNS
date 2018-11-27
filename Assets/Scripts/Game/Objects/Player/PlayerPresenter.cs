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
        [SerializeField] private float groundCheckRange = 5f;

        private PlayerModel Model { get; set; }
        private PlayerView View { get { return GetComponent<PlayerView>(); } }

        private void Start()
        {
            Initialize();
        }

        // NOTE: 안정성을 위해 초기 RectTransform 수치도 지정할까..
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

            ObserveIsGround().Subscribe(isGround => Debug.Log(isGround)).AddTo(this);
        }

        private IObservable<bool> ObserveIsGround()
        {
            var charaHalfHeightToVector = new Vector3(0, GetComponent<RectTransform>().rect.height / 2, 0);
            return Observable.EveryUpdate()
                .Select(_ => 
                {
                    var footPosition = transform.position - charaHalfHeightToVector;
                    var hit = Physics2D.Raycast(footPosition, -Vector2.up, groundCheckRange);
                    
                    return hit.collider != null;
                })
                .DistinctUntilChanged();
        }
    }
}