using UnityEngine;
using sns.Scene;
using sns.Data;
using sns.Path;
using sns.Character;

using UniRx;

namespace sns.MainMenu
{
    [RequireComponent(typeof(MainMenuView))]
    public class MainMenuPresenter : MonoBehaviour
    {
        [SerializeField] private Transform dialogRoot;

        private MainMenuView View { get { return GetComponent<MainMenuView>(); } }

        private CharaSelectDialogPresenter charaSelectDialog;

        // FIXME: 완전 이상하므로 월드모델을 만들어서 나중에 이동해야함
        private CharactersModel charactersModel = new CharactersModel();

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
            var prefab = Resources.Load<CharaSelectDialogPresenter>(PathModel.CharaSelectPrefabPath);
            charaSelectDialog = Instantiate(prefab, dialogRoot);
            charaSelectDialog.Open();
            charaSelectDialog.OnClose.Subscribe(_ => Redraw()).AddTo(this);
        }

        private void Redraw()
        {
            var type = DataService.Instance.LoadCurrentChara();
            var model = charactersModel.Characters[type];
            View.Redraw(model);
        }
    }
}