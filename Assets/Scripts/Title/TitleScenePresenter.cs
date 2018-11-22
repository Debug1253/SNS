using UnityEngine;
using UnityEngine.SceneManagement;

using UniRx;

namespace sns.Title
{
    [RequireComponent(typeof(TitleSceneView))]
    public class TitleScenePresenter : MonoBehaviour
    {
        private TitleSceneView View { get { return GetComponent<TitleSceneView>(); } }

        void Start()
        {
            InitEventHandler();
        }

        private void InitEventHandler()
        {
            View.OnTap.Where(onTap => onTap)
                .Subscribe(_ => LoadMainMenu())
                .AddTo(this);
        }

        private void LoadMainMenu()
        {
            // NOTE: 씬관리하는 클래스를 작성하고 싶다.
            SceneManager.LoadScene(SceneNameModel.MainMenu);
        }
    }
}