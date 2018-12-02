using System;
using UnityEngine;
using UnityEngine.UI;
using sns.Character;
using sns.Path;

using UniRx;

namespace sns.MainMenu
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button stageSelectButton;
        [SerializeField] private Button charaSelectButton;
        [SerializeField] private Image CurrentCharaImage;

        public IObservable<Unit> OnStageSelectButton { get { return stageSelectButton.OnClickAsObservable(); } }
        public IObservable<Unit> OnCharaSelectButton { get { return charaSelectButton.OnClickAsObservable(); } }

        public void Redraw(CharacterModel model)
        {
            // FIXME: Sprite관련 서비스를 만들어야함
            CurrentCharaImage.sprite = Resources.Load<Sprite>(PathModel.GetCharaPath(model.Type));
        }
    }
}