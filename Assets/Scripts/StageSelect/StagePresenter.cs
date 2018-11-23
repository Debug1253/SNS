using UnityEngine;
using sns.Scene;

using UniRx;

namespace sns.StageSelect
{
    [RequireComponent(typeof(StageView))]
    public class StagePresenter : MonoBehaviour
    {
        private StageView View { get { return GetComponent<StageView>(); } }

        void Start()
        {
            InitEventHandler();
        }

        private void InitEventHandler()
        {
            // FIXME: 스테이지 선택 기능 추가
            View.OnLevelButton.Subscribe(level => SceneService.Instance.LoadGame(0, level)).AddTo(this);
        }
    }
}