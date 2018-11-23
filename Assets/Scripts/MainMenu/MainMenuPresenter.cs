using UnityEngine;
using sns.Scene;

using UniRx;

namespace sns.MainMenu
{
    [RequireComponent(typeof(MainMenuView))]
    public class MainMenuPresenter : MonoBehaviour
    {
        private MainMenuView View { get { return GetComponent<MainMenuView>(); } }

        void Start()
        {
            InitEventHandler();
        }

        private void InitEventHandler()
        {
            View.OnStageSelectButton.Subscribe(_ => SceneService.Instance.LoadStageSelect()).AddTo(this);
        }
    }
}