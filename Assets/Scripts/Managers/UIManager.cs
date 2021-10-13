using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tetris.Managers
{
    public class UIManager : SingletonInstance<UIManager>
    {
        [Header("Player UI.")]
        [SerializeField]
        private TMP_Text pointsText;

        [Header("End Panel.")]
        [SerializeField]
        private GameObject endPanel;
        [SerializeField]
        private TMP_Text endGamePointsText;
        [SerializeField]
        private GameObject newRecordText;

        private GameManager gameManager;

        private void Start()
        {
            gameManager = GameManager.GetInstance();
            gameManager.onEndGame += EndGame;

            endPanel.SetActive(false);
        }

        public void SetPointsText(int points)
        {
            pointsText.SetText(points.ToString());
        }

        private void EndGame()
        {
            newRecordText.SetActive(gameManager.IsNewRecord());
            endGamePointsText.SetText(gameManager.Points.ToString());
            endPanel.SetActive(true);
        }
    }
}