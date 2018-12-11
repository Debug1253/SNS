using System;
using UnityEngine;
using sns.Character;
using sns.Data;

using UniRx;

namespace sns.MainMenu
{
    [RequireComponent(typeof(CharaSelectDialogView))]
    public class CharaSelectDialogPresenter : MonoBehaviour
    {
        private CharaSelectDialogView View { get { return GetComponent<CharaSelectDialogView>(); } }

        private Subject<Unit> onClose = new Subject<Unit>(); 
        public IObservable<Unit> OnClose { get { return onClose; } }

        void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            InitEventHandler();
        }

        private void InitEventHandler()
        {
            View.OnCharaSelect.Subscribe(chara =>
            {
                SaveCharaData(chara);
                Close();
            }).AddTo(this);
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        private void Close()
        {
            gameObject.SetActive(false);

            onClose.OnNext(Unit.Default);
        }

        private void SaveCharaData(CharaType type)
        {
            DataService.Instance.SaveCurrentChara(type);
        }
    }
}