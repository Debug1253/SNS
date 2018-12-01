using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

namespace sns.MainMenu
{
    [RequireComponent(typeof(CharaSelectDialogView))]
    public class CharaSelectDialogPresenter : MonoBehaviour
    {
        private CharaSelectDialogView View { get { return GetComponent<CharaSelectDialogView>(); } }

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
                SaveCharaData();
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
        }

        private void SaveCharaData()
        {
            // NOTE: 데이터 보존 필요
        }
    }
}