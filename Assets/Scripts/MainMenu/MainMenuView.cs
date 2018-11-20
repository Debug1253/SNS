using UnityEngine;
using UnityEngine.UI;

using UniRx;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button stageSelectButton;

    public IObservable<Unit> OnStageSelectButton { get { return stageSelectButton.OnClickAsObservable(); } }
}
