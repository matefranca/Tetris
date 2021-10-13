using UnityEngine;
using UnityEngine.UI;
using Tetris.Scenes;

namespace Tetris.Managers
{
    public class MenuManager : SingletonInstance<MenuManager>
    {
        [Header("Buttons.")]
        [SerializeField]
        private Button play1PButton;
        [SerializeField]
        private Button play2PButton;
        [SerializeField]
        private Button quitGameButton;

        private void Start()
        {
            play1PButton.onClick.RemoveAllListeners();
            play1PButton.onClick.AddListener(PlayGame1P);

            play2PButton.onClick.RemoveAllListeners();
            play2PButton.onClick.AddListener(PlayGame2P);

            quitGameButton.onClick.RemoveAllListeners();
            quitGameButton.onClick.AddListener(QuitGame);

            if (AudioManager.GetInstance() && !AudioManager.GetInstance().IsPlaying(GameData.gameSoundName))
                AudioManager.GetInstance().Play(GameData.gameSoundName);
        }

        public void PlayGame1P()
        {
            SceneLoader.GetInstance().LoadScene(GameData.singleGameSceneName);
        }

        public void PlayGame2P()
        {
            SceneLoader.GetInstance().LoadScene(GameData.onlineGameSceneName);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}