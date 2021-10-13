using UnityEngine;
using Tetris.Game;

namespace Tetris.Managers
{
    public class GridManager : SingletonInstance<GridManager>
    {
        [Header("Pieces Drop Time.")]
        public float dropTime = 0.9f;
        public float fastDropTime = 0.05f;

        [Header("Next Piece Position")]
        [SerializeField]
        private Transform nextPiecePosistion;

        [Header("Offset.")]
        [SerializeField]
        private Vector3 offsetVector;

        [Header("Block Pieces.")]
        [SerializeField]
        private GameObject[] pieces = null;

        public Transform[,] grid;

        public static int height = 30;
        public static int width = 15;

        private GameManager gameManager;
        private EffectsManager effectsManager;

        private GameObject nextPiece;

        private void Start()
        {
            gameManager = GameManager.GetInstance();
            effectsManager = EffectsManager.GetInstance();

            grid = new Transform[width, height];

            GenerateNextPiece();
            SpawnPiece();
        }

        public void GenerateNextPiece()
        {
            int rand = Random.Range(0, pieces.Length);
            nextPiece = Instantiate(pieces[rand], nextPiecePosistion.position, Quaternion.identity, nextPiecePosistion);
            nextPiece.GetComponent<Pieces>().enabled = false;
        }

        public void SpawnPiece()
        {
            nextPiece.transform.parent = null;
            nextPiece.transform.position = transform.position;
            nextPiece.GetComponent<Pieces>().enabled = true;
            GenerateNextPiece();
        }

        public void ClearLine()
        {
            for (int y = 0; y < height; y++)
            {
                if (IsLineComplete(y))
                {
                    DestroyLine(y);
                    MoveLines(y);
                    gameManager.AddPoints();
                    ClearLine();
                }
            }

        }

        private bool IsLineComplete(int _y)
        {
            for (int x = 1; x < width; x++)
            {
                if (grid[x, _y] == null)
                    return false;
            }
            return true;
        }

        private void DestroyLine(int _y)
        {
            for (int x = 1; x < width; x++)
            {
                Destroy(grid[x, _y].gameObject);
                grid[x, _y] = null;
            }

            Vector3 _pos = new Vector3(7f, _y, 0f);
            effectsManager.PlayParticle(_pos);
        }

        private void MoveLines(int _y)
        {
            for (int i = _y; i < height; i++)
            {
                for (int x = 1; x < width; x++)
                {
                    if (grid[x, i] != null)
                    {
                        Debug.Log("moved");
                        grid[x, i - 1] = grid[x, i];
                        grid[x, i] = null;
                        grid[x, i - 1].transform.position -= new Vector3(0, 1, 0);
                    }
                }
            }
        }

        public void CheckLost()
        {
            gameManager.CheckLost();
        }

        public void StoreBlockInGrid(Transform block, int x, int y)
        {
            int xOffset = (int)(x - offsetVector.x);
            int yOffset = (int)(y - offsetVector.y);

            grid[xOffset, yOffset] = block;
        }
    }
}