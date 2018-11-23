using UnityEngine;
using UnityEngine.SceneManagement;

using UniRx;

namespace sns.Game
{
    [RequireComponent(typeof(GameView))]
    public class GamePresenter : MonoBehaviour
    {
        private GameView View { get { return GetComponent<GameView>(); } }

        void Start()
        {
            InitEventHandler();
        }

        private void InitEventHandler()
        {

        }
    }
}