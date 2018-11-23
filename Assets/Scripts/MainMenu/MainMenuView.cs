using System;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

namespace sns.MainMenu
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button stageSelectButton;

        public IObservable<Unit> OnStageSelectButton { get { return stageSelectButton.OnClickAsObservable(); } }
    }
}