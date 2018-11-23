using UnityEngine.SceneManagement;

namespace sns.Scene
{
    public class SceneService
    {
        private static SceneService instance;
        public static SceneService Instance
        {
            get
            {
                if (instance == null)
                    instance = new SceneService();

                return instance;
            }
        }

        public void LoadTitle()
        {
            SceneManager.LoadScene(SceneNameModel.Title);
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene(SceneNameModel.MainMenu);
        }

        public void LoadStageSelect()
        {
            SceneManager.LoadScene(SceneNameModel.StageSelect);
        }

        public void LoadGame(int stage, int level)
        {
            SceneManager.LoadScene(SceneNameModel.Game);
            // FIXME: 해당 스테이지, 레벨로 이동하는 기능 추가
        }
    }
}