using System;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

namespace sns.MainMenu
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button stageSelectButton;
        [SerializeField] private Button charaSelectButton;

        public IObservable<Unit> OnStageSelectButton { get { return stageSelectButton.OnClickAsObservable(); } }
        public IObservable<Unit> OnCharaSelectButton { get { return charaSelectButton.OnClickAsObservable(); } }
    }
}