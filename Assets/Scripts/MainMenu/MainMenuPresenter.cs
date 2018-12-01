using UnityEngine;
using sns.Scene;

using UniRx;

namespace sns.MainMenu
{
    [RequireComponent(typeof(MainMenuView))]
    public class MainMenuPresenter : MonoBehaviour
    {
        [SerializeField] private Transform dialogRoot;

        private MainMenuView View { get { return GetComponent<MainMenuView>(); } }

        private CharaSelectDialogPresenter charaSelectDialog;

        void Start()
        {
            InitEventHandler();
        }

        private void InitEventHandler()
        {
            View.OnStageSelectButton.Subscribe(_ => SceneService.Instance.LoadStageSelect()).AddTo(this);
            View.OnCharaSelectButton.Subscribe(_ => OnCharaSelect()).AddTo(this);
        }

        private void OnCharaSelect()
        {
            if (charaSelectDialog == null)
            {
                CreateCharaSelectDialog();
                return;
            }

            charaSelectDialog.Open();
        }

        private void CreateCharaSelectDialog()
        {
            var prefab = Resources.Load<CharaSelectDialogPresenter>(Path.PathModel.CharaSelectPrefabPath);
            charaSelectDialog = Instantiate(prefab, dialogRoot);
            charaSelectDialog.Open();
        }
    }
}