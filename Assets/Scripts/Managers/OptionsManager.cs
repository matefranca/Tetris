using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Tetris.Scenes;

namespace Tetris.Managers
{
    public class OptionsManager : SingletonInstance<OptionsManager>
    {
        [Header("Buttons.")]
        [SerializeField]
        private Button menuButton;
        [SerializeField]
        private Button endPanelReplayButton;
        [SerializeField]
        private Button endPanelMenuButton;

        void Start()
        {
            menuButton.onClick.RemoveAllListeners();
            menuButton.onClick.AddListener(GoToMenu);

            endPanelReplayButton.onClick.RemoveAllListeners();
            endPanelReplayButton.onClick.AddListener(RestartGame);

            endPanelMenuButton.onClick.RemoveAllListeners();
            endPanelMenuButton.onClick.AddListener(GoToMenu);
        }

        public void GoToMenu()
        {
            SceneLoader.GetInstance().LoadScene(GameData.menuSceneName);
        }

        public void RestartGame()
        {
            SceneLoader.GetInstance().LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}