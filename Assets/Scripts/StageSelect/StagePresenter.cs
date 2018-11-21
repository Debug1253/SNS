using UnityEngine;
using UnityEngine.SceneManagement;

using UniRx;

[RequireComponent(typeof(StageView))]
public class StagePresenter : MonoBehaviour
{
    private StageView View { get { return GetComponent<StageView>(); } }

	void Start ()
    {
        InitEventHandler();
    }

    private void InitEventHandler()
    {
        View.OnLevelButton
            .Subscribe(level =>
            {
                SetLevel(level);
                LoadGame();
            }).AddTo(this);
    }

    private void SetLevel(int level)
    {
        // NOTE: 나중에 Level을 저장하고 게임씬에서 취득할 수 있도록 기능 추가 필요.
        Debug.Log(level);
    }

    private void LoadGame()
    {
        // NOTE: 씬관리하는 클래스를 작성하고 싶다.
        SceneManager.LoadScene(SceneNameModel.Game);
    }
}
