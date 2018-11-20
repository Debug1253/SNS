using UnityEngine;
using UnityEngine.SceneManagement;

using UniRx;

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
        View.OnStageSelectButton.Subscribe(_ => LoadStageSelect()).AddTo(this);
    }

    private void LoadStageSelect()
    {
        // NOTE: 씬관리하는 클래스를 작성하고 싶다.
        SceneManager.LoadScene(SceneNameModel.StageSelect);
    }
}
