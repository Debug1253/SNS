using System;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

namespace sns.MainMenu
{
    public class CharaSelectDialogCharaView : MonoBehaviour
    {
        [SerializeField] private Button charaButton;
        // [SerializeField] private Text InfoText;

        public IObservable<UniRx.Unit> OnCharaSelect { get { return charaButton.OnClickAsObservable(); } }
    }
}