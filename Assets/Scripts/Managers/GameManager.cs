namespace Tetris.Managers
{
    public class GameManager : SingletonInstance<GameManager>
    {
        public int Points { get; private set; }
        public int Record { get; private set; }

        private bool lost = false;

        private UIManager uIManager;
        private GridManager gridManager;

        public delegate void OnEndGame();
        public OnEndGame onEndGame;

        private void Start()
        {
            uIManager = UIManager.GetInstance();
            gridManager = GridManager.GetInstance();

            if (AudioManager.GetInstance() && !AudioManager.GetInstance().IsPlaying(GameData.gameSoundName))
                AudioManager.GetInstance().Play(GameData.gameSoundName);
        }

        public void AddPoints()
        {
            Points += 10;
            uIManager.SetPointsText(Points);

            if (AudioManager.GetInstance())
                AudioManager.GetInstance().Play(GameData.pointSoundName);
        }

        public bool IsNewRecord()
        {
            return Record > Points;
        }

        public void CheckLost()
        {
            for (int x = 1; x < GridManager.width; x++)
            {
                if (gridManager.grid[x, 20] != null)
                    LostGame();
            }
        }

        private void LostGame()
        {
            if (!lost)
            {
                onEndGame?.Invoke();
                lost = true;

                if (AudioManager.GetInstance())
                    AudioManager.GetInstance().Play(GameData.defeatSoundName);
            }
        }
    }
}