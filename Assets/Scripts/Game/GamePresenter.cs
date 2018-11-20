using UnityEngine;
using UnityEngine.SceneManagement;

using UniRx;

[RequireComponent(typeof(GameView))]
public class GamePresenter : MonoBehaviour
{
    private GameView View { get { return GetComponent<GameView>(); } }

	void Start ()
    {
        InitEventHandler();
    }
	
    private void InitEventHandler()
    {
        View.OnGoToTitle.Subscribe(_ => LoadTitle()).AddTo(this);
    }

    private void LoadTitle()
    {
        // NOTE: 씬관리하는 클래스를 작성하고 싶다.
        SceneManager.LoadScene(SceneNameModel.Title);
    }
}
