using UnityEngine;
using UnityEngine.SceneManagement;
using sns.Scene;

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
            View.OnTap.Where(onTap => onTap).Subscribe(_ => SceneService.Instance.LoadMainMenu()).AddTo(this);
        }
    }
}